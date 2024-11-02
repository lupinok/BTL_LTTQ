using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class BoPhan_BUS
    {
        private readonly BTLMonLTTQEntities db;
        public BoPhan_BUS()
        {
            db = new BTLMonLTTQEntities();
        }
        public BoPhan GetItem(int maBoPhan)
        {
            return db.BoPhans.FirstOrDefault(x => x.MaBoPhan == maBoPhan);
        }

        public List<BoPhan> GetList()
        {
            return db.BoPhans.ToList();
        }
        private void ValidateBoPhan(BoPhan bp)
        {
            if (bp == null)
                throw new ArgumentNullException(nameof(bp), "Dữ liệu bộ phận không được để trống");

            if (bp.MaBoPhan <= 0)
                throw new Exception("Mã bộ phận không được để trống");

            if (string.IsNullOrEmpty(bp.TenBoPhan))
                throw new Exception("Tên bộ phận không được để trống");

        }
        public BoPhan Add(BoPhan bp)
        {
            try
            {
                ValidateBoPhan(bp);
                var exists = db.BoPhans.FirstOrDefault(x => x.MaBoPhan == bp.MaBoPhan);
                if (exists != null)
                    throw new Exception($"Mã chức vụ {bp.MaBoPhan} đã tồn tại");
                db.BoPhans.Add(bp);
                db.SaveChanges();
                return bp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thêm chức vụ: {ex.Message}");
            }
        }
        public void Delete(int maBoPhan)
        {
            try
            {
                var boPhan = db.BoPhans.FirstOrDefault(x => x.MaBoPhan == maBoPhan);
                if (boPhan == null)
                    throw new Exception($"Không tìm thấy bộ phận với mã {maBoPhan}");


                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.BoPhans.Remove(boPhan);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xóa chức vụ: {ex.Message}");
            }
        }
        public BoPhan Update(BoPhan pb)
        {
            try
            {
                ValidateBoPhan(pb);

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var existingBoPhan = db.BoPhans.FirstOrDefault(x => x.MaBoPhan == pb.MaBoPhan);
                        if (existingBoPhan == null)
                            throw new Exception($"Không tìm thấy phòng ban với mã {pb.MaBoPhan}");
                        existingBoPhan.TenBoPhan = pb.TenBoPhan;
                        db.SaveChanges();
                        transaction.Commit();
                        return existingBoPhan;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật phòng ban: {ex.Message}");
            }
        }

    }
}
