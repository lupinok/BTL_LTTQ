using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
	internal interface IHopDong_BaoHiem_BUS
	{
		DataTable GetBaoHiemDetails(int employeeId);

		// Method to insert a new insurance record
		bool InsertBaoHiem(int maBaoHiem, DateTime ngayDong, DateTime ngayHetHan, decimal mucDong, int maNhanVien, string tenBaoHiem);

		// Method to get contract details for a specific employee
		DataTable GetHopDongDetails(int employeeId);

		// Method to insert a new labor contract
		bool InsertHopDong(int maHopDong, string loaiHopDong, DateTime ngayBatDau, DateTime ngayKetThuc, decimal luongHopDong, int maNhanVien, string noiDungHopDong);
	}
}
