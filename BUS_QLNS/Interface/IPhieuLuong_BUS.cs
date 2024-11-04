using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS.Interface
{
    public interface IPhieuLuong_BUS
    {
        PhieuLuong getItem(int mpc);

        // Phương thức lấy danh sách phiếu lương theo kỳ công
        List<PhieuLuong> getList(int makycong);

        // Phương thức thêm phiếu lương
        void ThemPhieuLuong(PhieuLuong pl);
        PhieuLuong Add(PhieuLuong pl);

        // Phương thức xóa phiếu lương
        void Delete(int mpc);

        // Phương thức kiểm tra đã tính lương
        bool KiemTraDaTinhLuong(int thang, int nam);

        // Phương thức tính lương
        List<PhieuLuong> TinhLuong(int maKyCong);

        // Phương thức lấy phiếu lương theo kỳ công
        List<PhieuLuong> LayPhieuLuongTheoKyCong(int maKyCong);
    }
}
