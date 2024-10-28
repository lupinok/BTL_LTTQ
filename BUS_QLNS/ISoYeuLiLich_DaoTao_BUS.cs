using System;
using System.Collections.Generic;
using System.Data;

namespace BUS_QLNS
{
	internal interface ISoYeuLiLich_DaoTao_BUS
	{
		 DataTable GetAllSoYeuLyLich();
        bool InsertSoYeuLyLich(int maNhanVien, string trinhDoHocVan, string kinhNghiem, string kyNang, string chungChi, string ngoaiNgu, DateTime ngayTao, string gioiTinh, string queQuan, string giaCanh);
        bool UpdateSoYeuLyLich(int maNhanVien, string trinhDoHocVan, string kinhNghiem, string kyNang, string chungChi, string ngoaiNgu, DateTime ngayTao, string gioiTinh, string queQuan, string giaCanh);
        bool DeleteSoYeuLyLich(int maNhanVien);

        // Methods for DaoTao table
        DataTable GetAllDaoTao();
        bool InsertDaoTao(int maDaoTao, string tenKhoa, string noiDung, DateTime ngayBatDau, DateTime ngayKetThuc, decimal chiPhi);
        bool UpdateDaoTao(int maDaoTao, string tenKhoa, string noiDung, DateTime ngayBatDau, DateTime ngayKetThuc, decimal chiPhi);
        bool DeleteDaoTao(int maDaoTao);
		DataTable GetThongTinDaoTao();
	}
}
