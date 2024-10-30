using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace GUI_QLNS.HeThong
{
    public partial class frmKetNoi : DevExpress.XtraEditors.XtraForm
    {
        public frmKetNoi()
        {
            InitializeComponent();
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            LoadSavedSettings();
        }

        /// <summary>
        /// Tải các cài đặt đã lưu từ Settings
        /// </summary>
        private void LoadSavedSettings()
        {
            try
            {
                // Tải các cài đặt đã lưu
                if (!string.IsNullOrEmpty(Properties.Settings.Default.LastServerName))
                {
                    txtServer.Text = Properties.Settings.Default.LastServerName;
                }

                if (!string.IsNullOrEmpty(Properties.Settings.Default.LastDatabaseName))
                {
                    cboDatabases.Text = Properties.Settings.Default.LastDatabaseName;
                }

                if (!string.IsNullOrEmpty(Properties.Settings.Default.LastUsername))
                {
                    txtUsername.Text = Properties.Settings.Default.LastUsername;
                }

                cbWindowsAuth.Checked = Properties.Settings.Default.UseWindowsAuth;

                // Nếu có server và đang dùng Windows Auth thì load luôn
                if (!string.IsNullOrEmpty(txtServer.Text) && cbWindowsAuth.Checked)
                {
                    LoadDatabases();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading saved settings: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lưu các cài đặt hiện tại vào Settings
        /// </summary>
        private void SaveCurrentSettings()
        {
            try
            {
                Properties.Settings.Default.LastServerName = txtServer.Text.Trim();
                Properties.Settings.Default.LastDatabaseName = cboDatabases.Text.Trim();
                Properties.Settings.Default.LastUsername = txtUsername.Text.Trim();
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error saving settings: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load danh sách database từ server
        /// </summary>
        private void LoadDatabases()
        {
            if (string.IsNullOrEmpty(txtServer.Text))
            {
                XtraMessageBox.Show("Please enter server name first.", 
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chỉ kiểm tra username/password khi KHÔNG dùng Windows Auth
            if (!cbWindowsAuth.Checked && (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text)))
            {
                XtraMessageBox.Show("Please enter username and password.", 
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = GetConnectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            cboDatabases.Properties.Items.Clear();
                            while (dr.Read())
                            {
                                cboDatabases.Properties.Items.Add(dr["name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading databases: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = !cbWindowsAuth.Checked;
            txtPassword.Enabled = !cbWindowsAuth.Checked;
        }

        private void btnLoadDatabases_Click(object sender, EventArgs e)
        {
            LoadDatabases();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    XtraMessageBox.Show("Test connection succeeded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    string efConnectionString = $@"metadata=res://*/QLNS.csdl|res://*/QLNS.ssdl|res://*/QLNS.msl;provider=System.Data.SqlClient;provider connection string=""{connectionString}""";
                    
                    string solutionDir = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                    
                    UpdateConnectionString("BTLMonLTTQEntities", efConnectionString, Path.Combine(solutionDir, "DAL", "App.config"));
                    UpdateConnectionString("BTLMonLTTQEntities", efConnectionString, Path.Combine(solutionDir, "BUS_QLNS", "App.config"));
                    UpdateConnectionString("BTLMonLTTQEntities", efConnectionString, Path.Combine(solutionDir, "GUI_QLNS", "App.config"));

                    // Lưu cài đặt trước khi đóng form
                    Properties.Settings.Default.LastServerName = txtServer.Text.Trim();
                    Properties.Settings.Default.LastDatabaseName = cboDatabases.Text.Trim();
                    Properties.Settings.Default.UseWindowsAuth = cbWindowsAuth.Checked;
                    if (!cbWindowsAuth.Checked)
                    {
                        Properties.Settings.Default.LastUsername = txtUsername.Text.Trim();
                    }
                    Properties.Settings.Default.Save();

                    XtraMessageBox.Show("Connection string saved successfully.", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateConnectionString(string name, string connectionString, string configPath)
        {
            string fullPath = Path.GetFullPath(configPath);
            XDocument doc = XDocument.Load(fullPath);
            
            var connectionStrings = doc.Descendants("connectionStrings").FirstOrDefault();
            if (connectionStrings != null)
            {
                var existingConnection = connectionStrings.Elements("add")
                    .FirstOrDefault(x => x.Attribute("name")?.Value == name);

                if (existingConnection != null)
                {
                    existingConnection.Attribute("connectionString").Value = connectionString;
                    if (name == "BTLMonLTTQEntities")
                    {
                        existingConnection.Attribute("providerName").Value = "System.Data.EntityClient";
                    }
                }
                else
                {
                    connectionStrings.Add(new XElement("add",
                        new XAttribute("name", name),
                        new XAttribute("connectionString", connectionString),
                        name == "BTLMonLTTQEntities" ? new XAttribute("providerName", "System.Data.EntityClient") : null
                    ));
                }
            }

            doc.Save(fullPath);
        }

        private string GetConnectionString()
        {
            string authentication = cbWindowsAuth.Checked ? "Integrated Security=True" : $"User ID={txtUsername.Text};Password={txtPassword.Text}";
            return $"Data Source={txtServer.Text};Initial Catalog={cboDatabases.Text};{authentication}";
        }

        // Thêm sự kiện khi text của Server thay đổi
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            // Clear danh sách database khi đổi server
            cboDatabases.Properties.Items.Clear();
            cboDatabases.Text = string.Empty;
        }
    }
}