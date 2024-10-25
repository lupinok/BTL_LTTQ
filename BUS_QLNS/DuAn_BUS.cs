using System;
using System.Data;
using DAL_QLNS;

namespace BUS_QLNS
{
    public class DuAn_BUS : IDuAn_BUS
    {
        private readonly DuAn_DAL _duAnDal;

        public DuAn_BUS(string connectionString)
        {
            _duAnDal = new DuAn_DAL(connectionString);
        }

        // Method to get all projects
        public DataTable GetAllProjects()
        {
            return _duAnDal.GetAllProjects();
        }

        // Method to insert a new project
        public bool InsertProject(int maDuAn, string tenDuAn, DateTime ngayBatDau, DateTime ngayKetThuc, decimal nganSach, string trangThai, string moTa)
        {
            return _duAnDal.InsertProject(maDuAn, tenDuAn, ngayBatDau, ngayKetThuc, nganSach, trangThai, moTa);
        }

        // Method to update an existing project
        public bool UpdateProject(int maDuAn, string tenDuAn, DateTime ngayBatDau, DateTime ngayKetThuc, decimal nganSach, string trangThai, string moTa)
        {
            return _duAnDal.UpdateProject(maDuAn, tenDuAn, ngayBatDau, ngayKetThuc, nganSach, trangThai, moTa);
        }

        // Method to delete a project
        public bool DeleteProject(int maDuAn)
        {
            return _duAnDal.DeleteProject(maDuAn);
        }
    }
}