using System;
using System.Data;

namespace BUS_QLNS
{
    public interface ITrangChu_BUS
    {
        DataTable GetEmployeeSummary();
        DataTable GetDepartmentSummary();
        DataTable GetProjectSummary();
        DataTable GetTodayAttendance();
        DataTable GetRecentActivities(int limit = 10);
        string GetUserRole(string tenDangNhap);
    }
}
