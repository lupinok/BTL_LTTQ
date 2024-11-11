using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS.Interface
{
    public interface IChucVu_BUS
    {
        // Lấy thông tin một chức vụ
        ChucVu GetItem(int MaChucVu);

        // Lấy danh sách tất cả chức vụ
        List<ChucVu> GetList();

        // Thêm chức vụ mới
        ChucVu Add(ChucVu cv);

        // Cập nhật thông tin chức vụ
        ChucVu Update(ChucVu cv);

        // Xóa chức vụ
        void Delete(int maChucVu);

        // Kiểm tra tên chức vụ đã tồn tại
        bool IsTenChucVuExists(string tenChucVu);
    }
}
