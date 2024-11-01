using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class BangCongNhanVienChiTiet_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public BANGCONG_NHANVIEN_CHITIET Add(BANGCONG_NHANVIEN_CHITIET bcct)
        {
            try
            {
                db.BANGCONG_NHANVIEN_CHITIET.Add(bcct);
                db.SaveChanges();
                return bcct;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
