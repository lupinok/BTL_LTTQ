﻿using System.Data.SqlClient;

namespace DAL_QLNS
{
    public class DatabaseConnection
    {
        private string connectionString = "Data Source=DESKTOP-14IEBEU\\SQLEXPRESS;Initial Catalog=BTLMonLTTQ;Integrated Security=True;";

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
