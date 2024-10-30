using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace DAL
{
    public class DatabaseConnection
    {
        public static string BuildConnectionString(string server, string database, string username = null, string password = null, bool windowsAuth = true)
        {
            try
            {
                if (windowsAuth)
                {
                    return $"Data Source={server};Initial Catalog={database};Integrated Security=True;TrustServerCertificate=True";
                }
                return $"Data Source={server};Initial Catalog={database};User ID={username};Password={password};TrustServerCertificate=True";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tạo chuỗi kết nối: " + ex.Message);
            }
        }

        public static bool TestConnection(string connectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<string> GetDatabases(string server, string username = null, string password = null, bool windowsAuth = true)
        {
            List<string> databases = new List<string>();
            string connectionString = BuildConnectionString(server, "master", username, password, windowsAuth);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                databases.Add(reader["name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách CSDL: " + ex.Message);
            }

            return databases;
        }

        public static void UpdateConfigFiles(string connectionString)
        {
            try
            {
                string efConnectionString = $@"metadata=res://*/QLNS.csdl|res://*/QLNS.ssdl|res://*/QLNS.msl;provider=System.Data.SqlClient;provider connection string=""{connectionString};MultipleActiveResultSets=True;App=EntityFramework""";

                // Danh sách các file config cần cập nhật
                string[] configPaths = new[]
                {
                    "App.config",
                    @"..\..\..\DAL\App.config",
                    @"..\..\..\BUS_QLNS\App.config",
                    @"..\..\..\GUI_QLNS\App.config"
                };

                foreach (string configPath in configPaths)
                {
                    if (File.Exists(configPath))
                    {
                        UpdateConnectionString(configPath, efConnectionString);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật file config: " + ex.Message);
            }
        }

        private static void UpdateConnectionString(string configPath, string newConnectionString)
        {
            try
            {
                XDocument doc = XDocument.Load(configPath);
                
                // Tìm và cập nhật connection string
                var connectionStrings = doc.Descendants("connectionStrings").FirstOrDefault();
                if (connectionStrings != null)
                {
                    var existingConnection = connectionStrings.Elements("add")
                        .FirstOrDefault(x => x.Attribute("name")?.Value == "BTLMonLTTQEntities");

                    if (existingConnection != null)
                    {
                        // Cập nhật connection string nếu đã tồn tại
                        existingConnection.Attribute("connectionString").Value = newConnectionString;
                    }
                    else
                    {
                        // Thêm mới nếu chưa tồn tại
                        connectionStrings.Add(new XElement("add",
                            new XAttribute("name", "BTLMonLTTQEntities"),
                            new XAttribute("connectionString", newConnectionString),
                            new XAttribute("providerName", "System.Data.EntityClient")));
                    }

                    // Lưu thay đổi
                    doc.Save(configPath);
                }
                else
                {
                    throw new Exception($"Không tìm thấy phần tử connectionStrings trong file {configPath}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật file {configPath}: {ex.Message}");
            }
        }

        public static bool ValidateServerName(string serverName)
        {
            return !string.IsNullOrWhiteSpace(serverName);
        }

        public static bool ValidateCredentials(string username, string password, bool windowsAuth)
        {
            if (windowsAuth) return true;
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }

        public static bool ValidateDatabaseName(string databaseName)
        {
            return !string.IsNullOrWhiteSpace(databaseName);
        }
    }
}
