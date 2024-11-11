using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
	internal interface IDuAn_BUS
	{
		DataTable GetAllProjects();

        // Method to insert a new project
        bool InsertProject(int maDuAn, string tenDuAn, DateTime ngayBatDau, DateTime ngayKetThuc, decimal nganSach, string trangThai, string moTa);

        // Method to update an existing project
        bool UpdateProject(int maDuAn, string tenDuAn, DateTime ngayBatDau, DateTime ngayKetThuc, decimal nganSach, string trangThai, string moTa);

        // Method to delete a project
        bool DeleteProject(int maDuAn);
	}
}
