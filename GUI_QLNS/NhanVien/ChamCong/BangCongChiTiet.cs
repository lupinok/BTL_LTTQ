﻿using BUS_QLNS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
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
    public partial class frmBangCongChiTiet : DevExpress.XtraEditors.XtraForm
    {
        KyCongChiTiet_BUS _kcct;
        public int _makycong;
        public int _thang;
        public int _nam;
        public frmBangCongChiTiet()
        {
            InitializeComponent();
        }
        
        private void frmBangCongChiTiet_Load(object sender, EventArgs e)
        {
            _kcct = new KyCongChiTiet_BUS();
            gcBangCongChiTiet.DataSource = _kcct.getList(_makycong);
			CustomView(_thang,_nam);
			cboThang.Text = _thang.ToString();
			cboNam.Text = _nam.ToString();
        }
        void loadBangCong()
        {
			gcBangCongChiTiet.DataSource = _kcct.getList(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text));
			CustomView(int.Parse(cboThang.Text),int.Parse(cboNam.Text));
		}

        private void btnPhatSinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _kcct.phatSinhKyCongChiTiet(int.Parse(cboThang.Text),int.Parse(cboNam.Text));
			loadBangCong();
        }

        private void btnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadBangCong();
        }

        private void CustomView(int thang, int nam)
		{
			gvBangCongChiTiet.RestoreLayoutFromXml(Application.StartupPath + @"\BangCong_Layout.xml");
			int i;
			foreach (GridColumn gridColumn in gvBangCongChiTiet.Columns)
			{				
				if (gridColumn.FieldName == "HOTEN") continue;

				RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
				textEdit.Mask.MaskType = MaskType.RegEx;
				textEdit.Mask.EditMask = @"\p{Lu}+";
				gridColumn.ColumnEdit = textEdit;
			}

			for (i = 1; i <= GetDayNumber(thang, nam); i++)
			{				
				DateTime newDate = new DateTime(nam, thang, i);

				GridColumn column = new GridColumn();
				column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
				string fieldName = "D" + i;
				switch (newDate.DayOfWeek.ToString())
				{
					case "Monday":
						column = gvBangCongChiTiet.Columns[fieldName];
						column.Caption = "T.Hai " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.Width = 30;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						break;

					case "Tuesday":
						column = gvBangCongChiTiet.Columns[fieldName];
						column.Caption = "T.Ba " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						break;

					case "Wednesday":
						column = gvBangCongChiTiet.Columns[fieldName];
						column.Caption = "T.Tư " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						break;
					case "Thursday":
						column = gvBangCongChiTiet.Columns[fieldName];
						column.Caption = "T.Năm " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						break;
					case "Friday":
						column = gvBangCongChiTiet.Columns[fieldName];
						column.Caption = "T.Sáu " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						break;
					case "Saturday":
						column = gvBangCongChiTiet.Columns[fieldName];
						column.Caption = "T.Bảy " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Red;
						column.AppearanceHeader.BackColor = Color.Violet;
						column.AppearanceHeader.BackColor2 = Color.Violet;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Khaki;
						column.OptionsColumn.AllowFocus = true;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						break;
					case "Sunday":
						column = gvBangCongChiTiet.Columns[fieldName];
						column.Caption = "CN " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = false;
						column.AppearanceHeader.ForeColor = Color.Red;
						column.AppearanceHeader.BackColor = Color.GreenYellow;
						column.AppearanceHeader.BackColor2 = Color.GreenYellow;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Orange;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						//column.OptionsColumn.AllowFocus = false;
						break;
				}
			}

            while (i <= 31)
            {
                gvBangCongChiTiet.Columns[i + 1].Visible = false;
                i++;
            }
            
        }
        private int GetDayNumber(int thang, int nam)
		{
			int dayNumber = 0;
			switch (thang)
			{
				case 2:
					dayNumber = (nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0 ? 29 : 28;
					break;

				case 4:
				case 6:
				case 9:
				case 11:
					dayNumber = 30;
					break;

				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					dayNumber = 31;
					break;
			}

			return dayNumber;
		}

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			loadBangCong();
        }
    }
}