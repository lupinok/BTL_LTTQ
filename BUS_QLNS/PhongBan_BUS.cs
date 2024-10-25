using System;
using System.Data;
using DAL_QLNS;

namespace BUS_QLNS
{
    public class PhongBan_BUS : IPhongBan_BUS
    {
        private readonly PhongBan_DAL _phongBanDAL;

        public PhongBan_BUS(string connectionString)
        {
            _phongBanDAL = new PhongBan_DAL(connectionString);
        }

        public DataTable GetAllDepartments()
        {
            return _phongBanDAL.GetAllDepartments();
        }

        public bool InsertDepartment(int maPhongBan, string tenPhongBan, int soLuongNhanVien, string truongPhong)
        {
            return _phongBanDAL.InsertDepartment(maPhongBan, tenPhongBan, soLuongNhanVien, truongPhong);
        }

        public bool UpdateDepartment(int maPhongBan, string tenPhongBan, int soLuongNhanVien, string truongPhong)
        {
            return _phongBanDAL.UpdateDepartment(maPhongBan, tenPhongBan, soLuongNhanVien, truongPhong);
        }

        public bool DeleteDepartment(int maPhongBan)
        {
            return _phongBanDAL.DeleteDepartment(maPhongBan);
        }
    }
}
