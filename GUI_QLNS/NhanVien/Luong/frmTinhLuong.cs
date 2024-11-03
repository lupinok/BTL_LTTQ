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
        bool _them;
        int _maPhieu;
        public frmTinhLuong()
        {
            InitializeComponent();
        }

        private void frmTinhLuong_Load(object sender, EventArgs e)
        {
            phieuLuongBus = new PhieuLuong_BUS();
            _them = false;
            cbThang.SelectedIndex = DateTime.Now.Month - 1;
            cbBaoHiem.Text = DateTime.Now.Year.ToString();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int thang = int.Parse(cbThang.Text);
                int nam = int.Parse(cbBaoHiem.Text);

                TinhLuongThang(thang, nam);
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

                // Kiểm tra xem đã tính lương chưa
                if (!phieuLuongBus.KiemTraDaTinhLuong(thang, nam))
                {
                    if (MessageBox.Show("Chưa tính lương cho tháng này. Bạn có muốn tính lương không?",
                        "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        TinhLuongThang(thang, nam);
                    }
                    return;
                }

                // Nếu đã tính lương rồi thì hiển thị
                var dsLuong = phieuLuongBus.LayPhieuLuongTheoThang(thang, nam);
                gcHDLD.DataSource = dsLuong;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị bảng lương: " + ex.Message);
            }
        }
        private void TinhLuongThang(int thang, int nam)
        {
            try
            {
                // Kiểm tra xem đã tính lương chưa
                if (phieuLuongBus.KiemTraDaTinhLuong(thang, nam))
                {
                    if (MessageBox.Show("Đã tính lương tháng này. Bạn có muốn tính lại không?",
                        "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                    phieuLuongBus.XoaPhieuLuongTheoThang(thang, nam);
                }

                // Tính lương mới
                var dsLuong = phieuLuongBus.TinhLuong(thang, nam);
                foreach (var luong in dsLuong)
                {
                    phieuLuongBus.ThemPhieuLuong(luong);
                }

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