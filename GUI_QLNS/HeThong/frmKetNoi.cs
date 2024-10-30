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
            LoadSavedSettings();
        }

        /// <summary>
        /// Tải các cài đặt đã lưu từ Settings
        /// </summary>
        private void LoadSavedSettings()
        {
            try
            {
                // Tải tên server
                if (!string.IsNullOrEmpty(Properties.Settings.Default.LastServerName))
                {
                    txtServer.Text = Properties.Settings.Default.LastServerName;
                }

                // Tải tên database
                if (!string.IsNullOrEmpty(Properties.Settings.Default.LastDatabaseName))
                {
                    cboDatabases.Text = Properties.Settings.Default.LastDatabaseName;
                }

                // Tải username
                if (!string.IsNullOrEmpty(Properties.Settings.Default.LastUsername))
                {
                    txtUsername.Text = Properties.Settings.Default.LastUsername;
                }

                // Nếu có tên server, tự động load danh sách database
                if (!string.IsNullOrEmpty(txtServer.Text))
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
                    SaveCurrentSettings();

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