using System;
using System.Data;

namespace BUS_QLNS
{
    public interface IDangNhap_BUS
    {
        bool ValidateUser(string username, string password);
        DataTable GetUserInfo(string username);
        bool ChangePassword(string username, string oldPassword, string newPassword);
    }
}
