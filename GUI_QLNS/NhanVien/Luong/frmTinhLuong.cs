using BUS_QLNS;
using DAL;
using DevExpress.XtraEditors;
using GUI_QLNS.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Windows.Documents;

namespace GUI_QLNS.NhanVien.Luong
{
    public partial class frmTinhLuong : DevExpress.XtraEditors.XtraForm
    {
        PhieuLuong_BUS phieuLuongBus;
        BangCongNhanVienChiTiet_BUS bangcongBus;
        PhongBan_BUS phongBanBus;

        List<PhieuLuong> lstPhieuLuong;
        int namky;
        public frmTinhLuong()
        {
            InitializeComponent();
        }
        private void LoadPhongBan()
        {
            var phongBanList = phongBanBus.GetList(); 
            cboPhongBan.DataSource = phongBanList;
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "MaPhongBan";
        }
        private void cbPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (cboPhongBan.SelectedValue != null)
            {
                int maPhongBan = Convert.ToInt32(cboPhongBan.SelectedValue);
                LoadLuongTheoPhongBan(maPhongBan);
            }
        }

        private void LoadLuongTheoPhongBan(int maPhongBan)
        {
            try
            {
                var dsLuong = phieuLuongBus.GetLuongByPhongBan(maPhongBan); // Giả sử bạn có phương thức này trong PhieuLuong_BUS
                gcHDLD.DataSource = dsLuong;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lương theo phòng ban: " + ex.Message);
            }
        }
        private void frmTinhLuong_Load(object sender, EventArgs e)
        {
            phieuLuongBus = new PhieuLuong_BUS();
            bangcongBus = new BangCongNhanVienChiTiet_BUS();
            phongBanBus = new PhongBan_BUS();
            LoadPhongBan();
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

                int maKyCong = (int)kyCong.MAKYCONG;

                // Kiểm tra xem đã tính lương chưa
                var dsLuong = phieuLuongBus.LayPhieuLuongTheoKyCong(maKyCong);
                if (dsLuong == null || !dsLuong.Any())
                {
                    if (MessageBox.Show("Chưa tính lương cho tháng này. Bạn có muốn tính lương không?",
                        "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // Tính và lưu lương mới
                        dsLuong = phieuLuongBus.TinhLuong(maKyCong);
                        lstPhieuLuong = phieuLuongBus.getList(maKyCong);
                        namky = maKyCong;
                    }
                    else
                    {
                        return;
                    }
                }
                else

                {
                    dsLuong = phieuLuongBus.TinhLuong(maKyCong);
                    gcHDLD.DataSource = dsLuong;
                    // Nếu đã có dữ liệu, lưu lại để in
                    lstPhieuLuong = phieuLuongBus.getList(maKyCong);
                    namky = maKyCong;
                }

                
                FormatGrid();

                gcHDLD.RefreshDataSource();
                gvHDLD.RefreshData();
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

                dsLuong = phieuLuongBus.TinhLuong(maKyCong);

                // Hiển thị kết quả
                gcHDLD.DataSource = dsLuong;
                lstPhieuLuong = phieuLuongBus.getList(maKyCong);
                namky = maKyCong;
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

            // Điều chỉnh chiều cao của dòng nếu cần
            gvHDLD.RowHeight = 25;  // Có thể điều chỉnh số này

            // Đảm bảo không có padding dư thừa
            gvHDLD.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            gvHDLD.Columns["NGAYCONG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvHDLD.Columns["NGAYCONG"].DisplayFormat.FormatString = "#,##0";

            // Đảm bảo cột hiển thị đúng kiểu số
            gvHDLD.Columns["NGAYCONG"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;

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
            gvHDLD.Columns["TienBaoHiem"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvHDLD.Columns["TienBaoHiem"].DisplayFormat.FormatString = "N0";
            
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptBangLuong rpt = new rptBangLuong(lstPhieuLuong,namky);
            rpt.ShowPreviewDialog();
        }
    }
}