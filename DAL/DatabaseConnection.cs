using System.Data.SqlClient;

namespace DAL_QLNS
{
    public class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
