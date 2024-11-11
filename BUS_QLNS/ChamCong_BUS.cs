using System;
using System.Data;
using DAL_QLNS;

namespace BUS_QLNS
{
    public class ChamCong_BUS : IChamCong_BUS
    {
        private readonly ChamCong_DAL _chamCongDAL;

        public ChamCong_BUS(string connectionString)
        {
            _chamCongDAL = new ChamCong_DAL(connectionString);
        }

        public DataTable GetAllAttendanceRecords()
        {
            return _chamCongDAL.GetAllAttendanceRecords();
        }

        public bool InsertAttendanceRecord(int maChamCong, DateTime ngayChamCong, TimeSpan gioVao, TimeSpan gioRa, int maNhanVien, string ketQuaChamCong)
        {
            // Add validation logic here if needed
            return _chamCongDAL.InsertAttendanceRecord(maChamCong, ngayChamCong, gioVao, gioRa, maNhanVien, ketQuaChamCong);
        }

        public bool UpdateAttendanceRecord(int maChamCong, DateTime ngayChamCong, TimeSpan gioVao, TimeSpan gioRa, int maNhanVien, string ketQuaChamCong)
        {
            // Add validation logic here if needed
            return _chamCongDAL.UpdateAttendanceRecord(maChamCong, ngayChamCong, gioVao, gioRa, maNhanVien, ketQuaChamCong);
        }

        public bool DeleteAttendanceRecord(int maChamCong)
        {
            return _chamCongDAL.DeleteAttendanceRecord(maChamCong);
        }

        public DataTable GetAttendanceRecordsByEmployee(int maNhanVien)
        {
            return _chamCongDAL.GetAttendanceRecordsByEmployee(maNhanVien);
        }

        public DataTable GetAttendanceRecordsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _chamCongDAL.GetAttendanceRecordsByDateRange(startDate, endDate);
        }
    }
}
