using System;
using System.Data;
using DAL_QLNS;

namespace BUS_QLNS
{
    public class DangNhap_BUS : IDangNhap_BUS
    {
        private readonly DangNhap_DAL _dangNhapDAL;

        public DangNhap_BUS(string connectionString)
        {
            _dangNhapDAL = new DangNhap_DAL(connectionString);
        }

        public bool ValidateUser(string username, string password)
        {
            return _dangNhapDAL.ValidateUser(username, password);
        }

        public DataTable GetUserInfo(string username)
        {
            return _dangNhapDAL.GetUserInfo(username);
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return _dangNhapDAL.ChangePassword(username, oldPassword, newPassword);
        }
    }
}
