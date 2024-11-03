using BUS_QLNS;
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

namespace GUI_QLNS.HeThong
{
    public partial class Password : DevExpress.XtraEditors.XtraForm
    {
        private TAIKHOAN_BUS _taikhoanBUS;
        private string _currentUser;
        
        public Password()
        {
            InitializeComponent();
            _taikhoanBUS = new TAIKHOAN_BUS();
            _currentUser = Program.CurrentUser;
            
            // Thiết lập PasswordChar cho textbox mật khẩu
            txtOP.UseSystemPasswordChar = true;
            txtNP.UseSystemPasswordChar = true;
            
            // Thêm sự kiện click cho nút Lưu
            btnLuu.Click += btnLuu_Click;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            // Hiển thị/ẩn mật khẩu
            txtOP.UseSystemPasswordChar = !ckPassword.Checked;
            txtNP.UseSystemPasswordChar = !ckPassword.Checked;
        }
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtOP.Text) || string.IsNullOrEmpty(txtNP.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_taikhoanBUS.UpdatePassword(_currentUser, txtOP.Text.Trim(), txtNP.Text.Trim()))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}