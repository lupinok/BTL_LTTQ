using System;
using System.Data;
using DAL_QLNS;

namespace BUS_QLNS
{
    public class TrangChu_BUS : ITrangChu_BUS
    {
        private readonly TrangChu_DAL _trangChuDAL;

        public TrangChu_BUS(string connectionString)
        {
            _trangChuDAL = new TrangChu_DAL(connectionString);
        }

        public DataTable GetEmployeeSummary()
        {
            return _trangChuDAL.GetEmployeeSummary();
        }

        public DataTable GetDepartmentSummary()
        {
            return _trangChuDAL.GetDepartmentSummary();
        }

        public DataTable GetProjectSummary()
        {
            return _trangChuDAL.GetProjectSummary();
        }

        public DataTable GetTodayAttendance()
        {
            return _trangChuDAL.GetTodayAttendance();
        }

        public DataTable GetRecentActivities(int limit = 10)
        {
            return _trangChuDAL.GetRecentActivities(limit);
        }

        public string GetUserRole(string tenDangNhap)
        {
            return _trangChuDAL.GetUserRole(tenDangNhap);
        }
    }
}
