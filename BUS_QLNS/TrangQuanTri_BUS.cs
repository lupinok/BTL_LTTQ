using System;
using System.Data;
using DAL_QLNS;

namespace BUS_QLNS
{
    public class TrangQuanTri_BUS : ITrangQuanTri_BUS
    {
        private readonly TrangQuanTri_DAL _trangQuanTriDAL;

        public TrangQuanTri_BUS(string connectionString)
        {
            _trangQuanTriDAL = new TrangQuanTri_DAL(connectionString);
        }

        public DataTable GetAccountInfo(string tenDangNhap)
        {
            return _trangQuanTriDAL.GetAccountInfo(tenDangNhap);
        }

        public bool CreateNewAccount(string tenDangNhap, string matKhau, string vaiTro, string trangThaiTaiKhoan)
        {
            return _trangQuanTriDAL.CreateNewAccount(tenDangNhap, matKhau, vaiTro, trangThaiTaiKhoan);
        }

        public bool UpdateAccountRole(string tenDangNhap, string newRole)
        {
            return _trangQuanTriDAL.UpdateAccountRole(tenDangNhap, newRole);
        }

        public DataTable GetAllAccounts()
        {
            return _trangQuanTriDAL.GetAllAccounts();
        }

        public DataTable GetActivityHistory(DateTime startDate, DateTime endDate)
        {
            return _trangQuanTriDAL.GetActivityHistory(startDate, endDate);
        }

        public DataTable GetActivityHistoryByAccount(string tenDangNhap)
        {
            return _trangQuanTriDAL.GetActivityHistoryByAccount(tenDangNhap);
        }

        public bool AddActivityLog(string loaiHoatDong, string tenDangNhap, string ghiChu)
        {
            return _trangQuanTriDAL.AddActivityLog(loaiHoatDong, tenDangNhap, ghiChu);
        }
    }
}
