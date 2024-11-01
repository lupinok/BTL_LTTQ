using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using GUI_QLNS.HeThong;
using System.Windows.Forms;

namespace GUI_QLNS
{
    internal class SP_Functions
    {
        // Đếm số ngày làm việc trong tháng
        public static int demSoNgayLamViecTrongThang(int thang, int nam)
        {
            int dem = 0;
            DateTime f = new DateTime(nam, thang, 1);
            int x = f.Month + 1;
            while (f.Month < x)
            {
                dem = dem + 1;
                if (f.DayOfWeek == DayOfWeek.Sunday)
                {
                    dem = dem - 1;
                }
                f = f.AddDays(1);
            }
            return dem;
        }

        public static int laySoNgayCuaThang(int thang, int nam)
        {
            return DateTime.DaysInMonth(nam, thang);
        }
        public static string layThuTrongTuan(int nam, int thang, int ngay)
        {
            string thu = "";
            DateTime newDate = new DateTime(nam, thang, ngay);
            switch (newDate.DayOfWeek.ToString())
            {
                case "Monday":
                    thu = "Thứ hai";
                    break;
                case "Tuesday":
                    thu = "Thứ ba";
                    break;
                case "Wednesday":
                    thu = "Thứ tư";
                    break;
                case "Thursday":
                    thu = "Thứ năm";
                    break;
                case "Friday":
                    thu = "Thứ sáu";
                    break;
                case "Saturday":
                    thu = "Thứ bảy";
                    break;
                case "Sunday":
                    thu = "Chủ nhật";
                    break;
            }
            return thu;
        }
        //=================================DB=====================================
        //Khai báo 1 biến SqlConnection
        private static SqlConnection con = new SqlConnection();
        //Hàm tạo kết nối

        public static void taoKetNoi()
        {
            try
            {
                // Lấy thông tin kết nối từ Settings
                string server = Properties.Settings.Default.LastServerName;
                string database = Properties.Settings.Default.LastDatabaseName;
                bool useWindowsAuth = Properties.Settings.Default.UseWindowsAuth;
                string username = Properties.Settings.Default.LastUsername;

                // Tạo connection string
                string connectionString;
                if (useWindowsAuth)
                {
                    connectionString = $"Data Source={server};Initial Catalog={database};Integrated Security=True;Encrypt=False";
                }
                else
                {
                    // Lấy password từ form kết nối
                    using (frmKetNoi frm = new frmKetNoi())
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            connectionString = frm.GetConnectionString();
                        }
                        else
                        {
                            throw new Exception("Vui lòng cung cấp thông tin kết nối!");
                        }
                    }
                }

                con.ConnectionString = connectionString;
                con.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //hàm đóng kết nối
        public static void dongKetNoi()
        {
            if (con != null && con.State == ConnectionState.Open)
                con.Close();
        }

        //Hàm đổ dữ liệu vào datatable
        public static DataTable getData(string query)
        {
            taoKetNoi();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dongKetNoi();
            }
            return dt;
        }

        //Hàm lấy dữ liệu bằng Dataset
        public static DataSet getDataSet(string query)
        {
            taoKetNoi();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //Hàm insert/update dữ liệu
        public static void execQuery(string query)
        {
            taoKetNoi();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dongKetNoi();
            }
        }
    }
}
