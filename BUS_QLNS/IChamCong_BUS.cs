using System;
using System.Data;

namespace BUS_QLNS
{
    public interface IChamCong_BUS
    {
        DataTable GetAllAttendanceRecords();

        // Method to insert a new attendance record
        bool InsertAttendanceRecord(int maChamCong, DateTime ngayChamCong, TimeSpan gioVao, TimeSpan gioRa, int maNhanVien, string ketQuaChamCong);

        // Method to update an existing attendance record
        bool UpdateAttendanceRecord(int maChamCong, DateTime ngayChamCong, TimeSpan gioVao, TimeSpan gioRa, int maNhanVien, string ketQuaChamCong);

        // Method to delete an attendance record
        bool DeleteAttendanceRecord(int maChamCong);

        // Additional methods specific to ChamCong
        DataTable GetAttendanceRecordsByEmployee(int maNhanVien);
        DataTable GetAttendanceRecordsByDateRange(DateTime startDate, DateTime endDate);
    }
}
