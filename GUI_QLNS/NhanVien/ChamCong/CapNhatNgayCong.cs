using BUS_QLNS;
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
        public int _cNgay;
        frmBangCongChiTiet frmBCCC = (frmBangCongChiTiet)Application.OpenForms["frmBangCongChiTiet"];
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(frmWaiting), true, true);
            string _valueChamCong = rdgChamCong.Properties.Items[rdgChamCong.SelectedIndex].Value.ToString();
            string _valueNgayNghi = rdgNgayNghi.Properties.Items[rdgNgayNghi.SelectedIndex].Value.ToString();
            string fieldName = "D" + _cNgay.ToString();
            var kcct = _kcct.getItem(_makycong, _manv);

            double? tongngaycong = kcct.TONGNGAYCONG;
            double? tongngayphep = kcct.NGAYPHEP;
            double? tongnghinghikhongphep = kcct.NGHIKHONGPHEP;
            double? tongngayle = kcct.CONGNGAYLE;//202201001=202201
            if (cldNgayCong.SelectionRange.Start.Year * 100 + cldNgayCong.SelectionRange.Start.Month != _makycong)
            {
                MessageBox.Show("Thực hiện chấm công không đúng kỳ công. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SplashScreenManager.CloseForm();
                return;
            }
            //Cập nhật KYCONGCHITIET=> cập nhật BANGCONG_NV_CT
            SP_Functions.execQuery("UPDATE KYCONGCHITIET SET " + fieldName + "='" + _valueChamCong + "' WHERE MAKYCONG=" + _makycong + " AND MaNhanVien=" + _manv);

            SplashScreenManager.CloseForm();
            frmBCCC.loadBangCong();
        }

        private void CapNhatNgayCong_Load(object sender, EventArgs e)
        {
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
    }
}