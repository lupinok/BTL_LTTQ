using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace GUI_QLNS.HeThong
{
    public partial class frmKetNoi : DevExpress.XtraEditors.XtraForm
    {
        public frmKetNoi()
        {
            InitializeComponent();
        }

        private void cbWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = !cbWindowsAuth.Checked;
            txtPassword.Enabled = !cbWindowsAuth.Checked;
        }

        private void btnLoadDatabases_Click(object sender, EventArgs e)
        {
            try
            {
                cboDatabase.Properties.Items.Clear();
                var databases = DAL.DatabaseConnection.GetDatabases(
                    txtServer.Text,
                    txtUsername.Text,
                    txtPassword.Text,
                    cbWindowsAuth.Checked
                );
                
                cboDatabase.Properties.Items.AddRange(databases.ToArray());
                if (cboDatabase.Properties.Items.Count > 0)
                    cboDatabase.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi tải danh sách CSDL: {ex.Message}");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServer.Text) || string.IsNullOrEmpty(cboDatabase.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin Server và CSDL!");
                return;
            }

            string connectionString = DAL.DatabaseConnection.BuildConnectionString(
                txtServer.Text,
                cboDatabase.Text,
                txtUsername.Text,
                txtPassword.Text,
                cbWindowsAuth.Checked
            );

            if (DAL.DatabaseConnection.TestConnection(connectionString))
            {
                XtraMessageBox.Show("Kết nối thành công!");
            }
            else
            {
                XtraMessageBox.Show("Kết nối thất bại! Vui lòng kiểm tra lại thông tin.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = DAL.DatabaseConnection.BuildConnectionString(
                    txtServer.Text,
                    cboDatabase.Text,
                    txtUsername.Text,
                    txtPassword.Text,
                    cbWindowsAuth.Checked
                );

                if (!DAL.DatabaseConnection.TestConnection(connectionString))
                {
                    XtraMessageBox.Show("Không thể kết nối đến cơ sở dữ liệu! Vui lòng kiểm tra lại thông tin.");
                    return;
                }

                DAL.DatabaseConnection.UpdateConfigFiles(connectionString);
                XtraMessageBox.Show("Đã lưu cấu hình kết nối thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi lưu cấu hình: {ex.Message}");
            }
        }
    }
}