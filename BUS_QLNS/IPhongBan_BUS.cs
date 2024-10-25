using System;
using System.Data;

namespace BUS_QLNS
{
    public interface IPhongBan_BUS
    {
        DataTable GetAllDepartments();
        bool InsertDepartment(int maPhongBan, string tenPhongBan, int soLuongNhanVien, string truongPhong);
        bool UpdateDepartment(int maPhongBan, string tenPhongBan, int soLuongNhanVien, string truongPhong);
        bool DeleteDepartment(int maPhongBan);
    }
}
