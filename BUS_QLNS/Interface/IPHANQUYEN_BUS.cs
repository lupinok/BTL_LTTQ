using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS.Interface
{
    public interface IPHANQUYEN_BUS
    {
        // Lấy danh sách mã phòng ban được phân quyền cho tài khoản
        List<int> GetPhongBanByTaiKhoan(string tenDangNhap);

        // Phân quyền cho tài khoản
        void PhanQuyen(string tenDangNhap, List<int> dsPhongBan);
    }
}
