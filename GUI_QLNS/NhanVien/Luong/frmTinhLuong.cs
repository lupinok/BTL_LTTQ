using BUS_QLNS;
using DAL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNS.NhanVien.Luong
{
    public partial class frmTinhLuong : DevExpress.XtraEditors.XtraForm
    {
        PhieuLuong_BUS phieuLuongBus;
        BangCongNhanVienChiTiet_BUS bangcongBus;
        bool _them;
        int _maPhieu;
        private bool _hasEditPermission;
        public frmTinhLuong()
        {
            InitializeComponent();
            // Kiểm tra vai trò
            string vaiTro = Properties.Settings.Default.VaiTro;
            _hasEditPermission = vaiTro != "Chỉnh sửa";

            // Ẩn các nút nếu không có quyền chỉnh sửa
            if (!_hasEditPermission)
            {
                btnThem.Enabled = false;
                btnIn.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void frmTinhLuong_Load(object sender, EventArgs e)
        {
            phieuLuongBus = new PhieuLuong_BUS();
            bangcongBus = new BangCongNhanVienChiTiet_BUS();
            _them = false;
            cbThang.SelectedIndex = DateTime.Now.Month - 1;
            cbBaoHiem.Text = DateTime.Now.Year.ToString();
        }
        private int LayMaKyCong(int thang, int nam)
        {
            var kyCong = bangcongBus.LayKyCongTheoThangNam(thang, nam);
            if (kyCong == null)
                throw new Exception($"Không tìm thấy kỳ công của tháng {thang}/{nam}");

            return (int)kyCong.MAKYCONG;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int thang = int.Parse(cbThang.Text);
                int nam = int.Parse(cbBaoHiem.Text);
                int maKyCong = LayMaKyCong(thang, nam);
                TinhLuongTheoKyCong(maKyCong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính lương: " + ex.Message);
            }
        }
        private void btnBangLuong_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(cbThang.Text, out int thang) ||
                    !int.TryParse(cbBaoHiem.Text, out int nam))
                {
                    MessageBox.Show("Vui lòng chọn tháng và năm hợp lệ!");
                    return;
                }

                // Lấy mã kỳ công từ tháng năm
                var kyCong = bangcongBus.LayKyCongTheoThangNam(thang, nam);
                if (kyCong == null)
                {
                    MessageBox.Show($"Không tìm thấy kỳ công của tháng {thang}/{nam}");
                    return;
                }


                // Kiểm tra xem đã tính lương chưa
                var dsLuong = phieuLuongBus.LayPhieuLuongTheoKyCong((int)kyCong.MAKYCONG);
                if (dsLuong == null || !dsLuong.Any())
                {
                    if (MessageBox.Show("Chưa tính lương cho tháng này. Bạn có muốn tính lương không?",
                        "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        TinhLuongTheoKyCong((int)kyCong.MAKYCONG);
                    }
                    return;
                }

                // Nếu đã tính lương rồi thì hiển thị
                gcHDLD.DataSource = dsLuong;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị bảng lương: " + ex.Message);
            }
        }
        private void TinhLuongTheoKyCong(int maKyCong)
        {
            try
            {
                // Kiểm tra xem đã tính lương chưa
                var dsLuong = phieuLuongBus.LayPhieuLuongTheoKyCong(maKyCong);
                if (dsLuong != null && dsLuong.Any())
                {
                    if (MessageBox.Show("Đã tính lương tháng này. Bạn có muốn tính lại không?",
                        "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                }

                // Tính lương mới
                dsLuong = phieuLuongBus.TinhLuong(maKyCong);

                // Hiển thị kết quả
                gcHDLD.DataSource = dsLuong;
                FormatGrid();

                MessageBox.Show("Tính lương thành công!");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tính lương: " + ex.Message);
            }
        }
        private void FormatGrid()
        {
            // Format các cột tiền tệ
            gvHDLD.Columns["LuongCoBan"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvHDLD.Columns["LuongCoBan"].DisplayFormat.FormatString = "N0";
            gvHDLD.Columns["TangCa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvHDLD.Columns["TangCa"].DisplayFormat.FormatString = "N0";
            gvHDLD.Columns["PhuCap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvHDLD.Columns["PhuCap"].DisplayFormat.FormatString = "N0";
            gvHDLD.Columns["UngLuong"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvHDLD.Columns["UngLuong"].DisplayFormat.FormatString = "N0";
            gvHDLD.Columns["KTKL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvHDLD.Columns["KTKL"].DisplayFormat.FormatString = "N0";
            gvHDLD.Columns["LuongNhanDuoc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvHDLD.Columns["LuongNhanDuoc"].DisplayFormat.FormatString = "N0";
        }
    }
}