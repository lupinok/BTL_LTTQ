using BUS_QLNS.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class PHANQUYEN_BUS : IPHANQUYEN_BUS
    {
        private readonly BTLMonLTTQEntities db;

        public PHANQUYEN_BUS()
        {
            db = new BTLMonLTTQEntities();
        }

        public List<int> GetPhongBanByTaiKhoan(string tenDangNhap)
        {
            return db.PhanQuyens
            .Where(x => x.TenDangNhap == tenDangNhap)
            .Select(x => x.MaPhongBan)
            .Select(x => x ?? 0) // Chuyển đổi int? sang int, với giá trị null sẽ thành 0
            .ToList();
        }

        public void PhanQuyen(string tenDangNhap, List<int> dsPhongBan)
        {
            // Xóa phân quyền cũ
            var oldPermissions = db.PhanQuyens.Where(x => x.TenDangNhap == tenDangNhap);
            db.PhanQuyens.RemoveRange(oldPermissions);

            // Thêm phân quyền mới
            foreach (var maPhongBan in dsPhongBan)
            {
                db.PhanQuyens.Add(new PhanQuyen
                {
                    TenDangNhap = tenDangNhap,
                    MaPhongBan = maPhongBan
                });
            }
            db.SaveChanges();
        }
    }
}
