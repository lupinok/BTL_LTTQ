using System;
using System.Data;

namespace BUS_QLNS
{
    public interface ITrangQuanTri_BUS
    {
        DataTable GetAccountInfo(string tenDangNhap);
        bool CreateNewAccount(string tenDangNhap, string matKhau, string vaiTro, string trangThaiTaiKhoan);
        bool UpdateAccountRole(string tenDangNhap, string newRole);
        DataTable GetAllAccounts();
        DataTable GetActivityHistory(DateTime startDate, DateTime endDate);
        DataTable GetActivityHistoryByAccount(string tenDangNhap);
        bool AddActivityLog(string loaiHoatDong, string tenDangNhap, string ghiChu);
    }
}
