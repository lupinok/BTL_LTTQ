using DAL;
using BUS_QLNS;
using BusinessLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class frmBangCongChiTiet : DevExpress.XtraEditors.XtraForm
    {
		NHANVIEN_BUS _nhanvien;
        KyCongChiTiet_BUS _kcct;
		KyCong_BUS _kycong;
		BangCongNhanVienChiTiet_BUS _bcnvct;
        public int _makycong;
        public int _thang;
        public int _nam;
        private GridHitInfo downHitInfo = null;
        public frmBangCongChiTiet()
        {
            InitializeComponent();
        }
        
        private void frmBangCongChiTiet_Load(object sender, EventArgs e)
        {
			_nhanvien = new NHANVIEN_BUS();
			_kycong = new KyCong_BUS();
            _kcct = new KyCongChiTiet_BUS();
			_bcnvct = new BangCongNhanVienChiTiet_BUS();
            gcBangCongChiTiet.DataSource = _kcct.getList(_makycong);
			CustomView(_thang,_nam);
			cboThang.Text = _thang.ToString();
			cboNam.Text = _nam.ToString();
        }
        public void loadBangCong()
        {
			_kcct = new KyCongChiTiet_BUS();
			gcBangCongChiTiet.DataSource = _kcct.getList(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text));
			CustomView(int.Parse(cboThang.Text),int.Parse(cboNam.Text));
		}

        private void btnPhatSinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(frmWaiting), true, true);
            if (_kycong.KiemTraPhatSinhKyCong(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text)))
            {
                MessageBox.Show("Kỳ công đã được phát sinh.", "Thông báo");
                SplashScreenManager.CloseForm();
                return;
            }

            List<DAL.NhanVien> lstNhanVien = _nhanvien.getList();
			_kcct.phatSinhKyCongChiTiet(int.Parse(cboThang.Text), int.Parse(cboNam.Text));
            foreach (var item in lstNhanVien)
            {
                for (int i = 1; i <= GetDayNumber(int.Parse(cboThang.Text), int.Parse(cboNam.Text)); i++)
                {
                    BANGCONG_NHANVIEN_CHITIET bcct = new BANGCONG_NHANVIEN_CHITIET();
                    bcct.MaNhanVien = item.MaNhanVien;
                    bcct.GIOVAO = "08:00";
                    bcct.GIORA = "17:00";
                    bcct.NGAY = DateTime.Parse(cboNam.Text + "-" + cboThang.Text + "-" + i.ToString());
                    bcct.THU = SP_Functions.layThuTrongTuan(int.Parse(cboNam.Text), int.Parse(cboThang.Text), i);
                    bcct.CONGNGAYLE = 0;
                    bcct.CONGCHUNHAT = 0;
                    bcct.NGAYPHEP = 0;
					if (bcct.THU == "Chủ nhật")
					{
                        bcct.KYHIEU = "CN";
						bcct.NGAYCONG = 0;
                    } 
                    else
                    {
                        bcct.KYHIEU = "X";
                        bcct.NGAYCONG = 1;
                    }
                    bcct.MAKYCONG = _makycong;
                    bcct.CREATED_DATE = DateTime.Now;
                    bcct.CREATED_BY = 1;
                    _bcnvct.Add(bcct);
                }
            }

            var kc = _kycong.getItem(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text));
            kc.TRANGTHAI = true;
            _kycong.Update(kc);
            SplashScreenManager.CloseForm();
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
			//foreach (GridColumn gridColumn in gvBangCongChiTiet.Columns)
			//{				
			//	if (gridColumn.FieldName == "HOTEN") continue;

			//	RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
			//	textEdit.Mask.MaskType = MaskType.RegEx;
			//	textEdit.Mask.EditMask = @"\p{Lu}+";
			//	gridColumn.ColumnEdit = textEdit;
			//}

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
						//column.OptionsColumn.AllowEdit = true;
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
						//column.OptionsColumn.AllowEdit = true;
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
						//column.OptionsColumn.AllowEdit = true;
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
						//column.OptionsColumn.AllowEdit = true;
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
						//column.OptionsColumn.AllowEdit = true;
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
                        //column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        //column.AppearanceHeader.ForeColor = Color.Red;
                        //column.AppearanceHeader.BackColor = Color.Violet;
                        //column.AppearanceHeader.BackColor2 = Color.Violet;
                        //column.AppearanceCell.ForeColor = Color.Black;
                        //column.AppearanceCell.BackColor = Color.Khaki;
                        //column.OptionsColumn.AllowFocus = true;
                        //column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
                        //column.Width = 30;
                        break;
					case "Sunday":
						column = gvBangCongChiTiet.Columns[fieldName];
						column.Caption = "CN " + Environment.NewLine + i;
						//column.OptionsColumn.AllowEdit = false;
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
        private void gvBangCongChiTiet_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridHitInfo hitInfo = gvBangCongChiTiet.CalcHitInfo(e.Location);
                
                // Kiểm tra xem click xuống và nhả chuột có cùng một cell không
                if (downHitInfo != null && 
                    hitInfo.InRowCell && 
                    downHitInfo.RowHandle == hitInfo.RowHandle && 
                    downHitInfo.Column == hitInfo.Column)
                {
                    // Đảm bảo focus vào cell được chọn
                    gvBangCongChiTiet.FocusedRowHandle = hitInfo.RowHandle;
                    gvBangCongChiTiet.FocusedColumn = hitInfo.Column;
                    
                    menu.Show(gcBangCongChiTiet, e.Location);
                }
            }
        }

        private void gvBangCongChiTiet_MouseDown(object sender, MouseEventArgs e)
        {
            downHitInfo = gvBangCongChiTiet.CalcHitInfo(e.Location);
        }
        private void mnCapNhatNgayCong_Click(object sender, EventArgs e)
        {
            CapNhatNgayCong frm = new CapNhatNgayCong();
            frm._makycong = _makycong;
            frm._manv = int.Parse(gvBangCongChiTiet.GetFocusedRowCellValue("MANV").ToString());
            frm._hoten = gvBangCongChiTiet.GetFocusedRowCellValue("HOTEN").ToString();
            frm._ngay = gvBangCongChiTiet.FocusedColumn.FieldName.ToString();

            // Lấy vị trí con trỏ chuột
            Point mousePosition = Control.MousePosition;

            // Lấy kích thước màn hình
            Rectangle screenBounds = Screen.GetWorkingArea(mousePosition);

            // Tính toán vị trí tối ưu
            int x = mousePosition.X;
            int y = mousePosition.Y;

            // Kiểm tra nếu form sẽ bị che khuất bên phải
            if (x + frm.Width > screenBounds.Right)
                x = screenBounds.Right - frm.Width;

            // Kiểm tra nếu form sẽ bị che khuất bên dưới
            if (y + frm.Height > screenBounds.Bottom)
                y = screenBounds.Bottom - frm.Height;

            // Đặt vị trí form
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(x, y);

            frm.ShowDialog();
        }
        private void gvBangCongChiTiet_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue == null)
            {
            }
            else
            {
                if (e.CellValue.ToString() == "CT")
                {
                    e.Appearance.BackColor = Color.DeepSkyBlue;
                    e.Appearance.ForeColor = Color.White;
                }
                if (e.CellValue.ToString() == "VR")
                {
                    e.Appearance.BackColor = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;
                }
                if (e.CellValue.ToString() == "P")
                {
                    e.Appearance.BackColor = Color.LightBlue;
                }
                if (e.CellValue.ToString() == "V")
                {
                    e.Appearance.BackColor = Color.IndianRed;
                    e.Appearance.ForeColor = Color.White;
                }
                if (e.CellValue.ToString() == "TS")
                {
                    e.Appearance.BackColor = Color.LightPink;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }
    }
}