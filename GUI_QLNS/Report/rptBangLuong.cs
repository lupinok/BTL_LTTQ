using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using DAL;
using System.Collections.Generic;
namespace GUI_QLNS.Report
{
    public partial class rptBangLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBangLuong()
        {
            InitializeComponent();
        }
        List<PhieuLuong> lst;
        int kycong;
        public rptBangLuong(List<PhieuLuong> lst,int kycong)
        {
            InitializeComponent();
            this.lst = lst;
            this.kycong = kycong;
            lblThangNam.Text = "Tháng " + kycong.ToString().Substring(4) + " năm " + kycong.ToString().Substring(0, 4);
            this.DataSource = lst;
            LoadData();
        }
        void LoadData()
        {
            
            lblMaNV.DataBindings.Add("Text", DataSource, "MaNhanVien");
            lblHoTen.DataBindings.Add("Text", DataSource, "HoTen");
            lblLuongCoBan.DataBindings.Add("Text", DataSource, "LuongCoBan");
            lblTangCa.DataBindings.Add("Text", DataSource, "TangCa");
            lblPhuCa.DataBindings.Add("Text", DataSource, "PhuCap");
            lblUngLuong.DataBindings.Add("Text", DataSource, "UngLuong");
            lblNgayCong.DataBindings.Add("Text", DataSource, "NGAYCONG");
            lblKTKL.DataBindings.Add("Text", DataSource, "KTKL");
            lblTienBaoHiem.DataBindings.Add("Text", DataSource, "TienBaoHiem");
            lblThucLanh.DataBindings.Add("Text", DataSource, "LuongNhanDuoc");
        }

    }
}
