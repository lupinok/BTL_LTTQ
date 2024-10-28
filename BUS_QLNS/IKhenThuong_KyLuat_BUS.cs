using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
	internal interface IKhenThuong_KyLuat_BUS
	{
		DataTable GetKT_KLDetails(int employeeId);

		// Method to insert a new reward or discipline record
		bool InsertKT_KL(int maNhanVien, int maSuKien, string chiTiet, decimal tienThuongPhat);

		// Method to update an existing reward or discipline record
		bool UpdateKT_KL(int maNhanVien, int maSuKien, string chiTiet, decimal tienThuongPhat);

		// Method to delete a reward or discipline record
		bool DeleteKT_KL(int maNhanVien, int maSuKien);
	}
}
