using BUS_QLNS;
using DAL;
using DevExpress.Utils.DirectXPaint;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNS.NhanVien.ChamCong
{
    public partial class CapNhatNgayCong : DevExpress.XtraEditors.XtraForm
    {
        public CapNhatNgayCong()
        {
            InitializeComponent();
        }
        public int _manv;
        public string _hoten;
        public int _makycong;
        public string _ngay;
        KyCongChiTiet_BUS _kcct;
        BangCongNhanVienChiTiet_BUS _bcct_nv;
        public int _cNgay;
        frmBangCongChiTiet frmBCCC = (frmBangCongChiTiet)Application.OpenForms["frmBangCongChiTiet"];
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(frmWaiting), true, true);
            string _valueChamCong = rdgChamCong.Properties.Items[rdgChamCong.SelectedIndex].Value.ToString();
            string _valueNgayNghi = rdgNgayNghi.Properties.Items[rdgNgayNghi.SelectedIndex].Value.ToString();
            string fieldName = "D" + _cNgay.ToString();
            var kcct = _kcct.getItem(_makycong, _manv);

            //double? tongngaycong = kcct.TONGNGAYCONG;
            //double? tongngayphep = kcct.NGAYPHEP;
            //double? tongnghinghikhongphep = kcct.NGHIKHONGPHEP;
            //double? tongngayle = kcct.CONGNGAYLE;//202201001=202201
            if (cldNgayCong.SelectionRange.Start.Year * 100 + cldNgayCong.SelectionRange.Start.Month != _makycong)
            {
                MessageBox.Show("Thực hiện chấm công không đúng kỳ công. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SplashScreenManager.CloseForm();
                return;
            }
            //Cập nhật KYCONGCHITIET=> cập nhật BANGCONG_NV_CT
            SP_Functions.execQuery("UPDATE KYCONGCHITIET SET " + fieldName + "='" + _valueChamCong + "' WHERE MAKYCONG=" + _makycong + " AND MaNhanVien=" + _manv);
            BANGCONG_NHANVIEN_CHITIET bcctnv = _bcct_nv.getItem(_makycong, _manv, cldNgayCong.SelectionStart.Day);
            bcctnv.KYHIEU = _valueChamCong;
            switch (_valueChamCong)
            {
                case "P":
                    if (_valueNgayNghi == "NN")
                    {
                        bcctnv.NGAYPHEP = 1;
                        bcctnv.NGAYCONG = 0;
                    }
                    else
                    {
                        bcctnv.NGAYPHEP = 0.5;
                        bcctnv.NGAYCONG = 0.5;
                    }
                    break;
                case "V":
                    bcctnv.NGAYCONG = 0;
                    bcctnv.NGAYPHEP = 0;
                    break;
                case "CT":
                    bcctnv.NGAYCONG = 1;
                    bcctnv.NGAYPHEP = 0;
                    break;
                case "VR":
                    if (_valueNgayNghi == "NN")
                    {
                        bcctnv.NGAYCONG = 0;
                        bcctnv.NGAYPHEP = 0;
                    }
                    else
                    {
                        bcctnv.NGAYCONG = 0.5;
                        bcctnv.NGAYPHEP = 0.5;
                    }
                    break;
                case "TS":
                    bcctnv.NGAYCONG = 0;
                    bcctnv.NGAYPHEP = 1;
                    break;
                default:
                    break;
            }
            //Update tb_BANGCONG_NV_CT
            _bcct_nv.Update(bcctnv);
            // Tính lại tổng các ngày: ngày phép, ngày công, ngày vắng,...
            double tongngaycong = _bcct_nv.tongNgayCong(_makycong, _manv);
            double tongngayphep = _bcct_nv.tongNgayPhep(_makycong, _manv);
            kcct.NGAYPHEP = tongngayphep;
            kcct.TONGNGAYCONG = tongngaycong;
            _kcct.Update(kcct);
            SplashScreenManager.CloseForm();
            frmBCCC.loadBangCong();
        }

        private void CapNhatNgayCong_Load(object sender, EventArgs e)
        {
            _bcct_nv = new BangCongNhanVienChiTiet_BUS();
            _kcct = new KyCongChiTiet_BUS();
            lbID.Text = _manv.ToString();
            lbHoTen.Text = _hoten;
            string nam = _makycong.ToString().Substring(0, 4);
            string thang = _makycong.ToString().Substring(4);
            string ngay = _ngay.Substring(1);
            DateTime dt = DateTime.Parse(nam + "-" + thang + "-" + ngay);
            cldNgayCong.SetDate(dt);
            _cNgay = dt.Day;
        }

        private void cldNgayCong_DateSelected(object sender, DateRangeEventArgs e)
        {
            _cNgay = cldNgayCong.SelectionRange.Start.Day;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(frmWaiting), true, true);

            try
            {
                // Lấy thông tin chấm công của ngày hiện tại
                BANGCONG_NHANVIEN_CHITIET bcctnv = _bcct_nv.getItem(_makycong, _manv, cldNgayCong.SelectionStart.Day);

                if (bcctnv.KYHIEU == "X")
                {
                    MessageBox.Show("Ngày này đã được đánh dấu là đi làm đủ (X).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Reset ký hiệu chấm công về "X" (đi làm đủ)
                bcctnv.KYHIEU = "X";
                bcctnv.NGAYCONG = 1;
                bcctnv.NGAYPHEP = 0;

                // Cập nhật BANGCONG_NHANVIEN_CHITIET
                _bcct_nv.Update(bcctnv);

                // Cập nhật trực tiếp vào KYCONGCHITIET
                string fieldName = "D" + _cNgay.ToString();
                SP_Functions.execQuery($"UPDATE KYCONGCHITIET SET {fieldName}='X' WHERE MAKYCONG={_makycong} AND MaNhanVien={_manv}");

                // Tính lại tổng các ngày
                double tongngaycong = _bcct_nv.tongNgayCong(_makycong, _manv);
                double tongngayphep = _bcct_nv.tongNgayPhep(_makycong, _manv);

                // Cập nhật tổng ngày công và ngày phép
                var kcct = _kcct.getItem(_makycong, _manv);
                kcct.NGAYPHEP = tongngayphep;
                kcct.TONGNGAYCONG = tongngaycong;
                _kcct.Update(kcct);

                // Làm mới dữ liệu
                frmBCCC.loadBangCong();
            }
            finally 
            {
                SplashScreenManager.CloseForm();
            }
        }
    }
}