using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS.Interface
{
    public interface IBoPhan_BUS
    {

        // Lấy thông tin một bộ phận
        BoPhan GetItem(int maBoPhan);

        // Lấy danh sách tất cả bộ phận
        List<BoPhan> GetList();

        // Thêm bộ phận mới
        BoPhan Add(BoPhan bp);

        // Cập nhật thông tin bộ phận
        BoPhan Update(BoPhan bp);

        // Xóa bộ phận
        void Delete(int maBoPhan);
    }
}
