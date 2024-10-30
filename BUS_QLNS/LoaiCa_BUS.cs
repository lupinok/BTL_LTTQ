using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class LOAICA_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public LoaiCa getItem(string maloaica)
        {
            return db.LoaiCas.FirstOrDefault(x => x.MaLoaiCa == maloaica);
        }

        public List<LoaiCa> getList()
        {
            return db.LoaiCas.ToList();
        }

        public LoaiCa Add(LoaiCa lc)
        {
            try
            {
                db.LoaiCas.Add(lc);
                db.SaveChanges();
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public LoaiCa Update(LoaiCa lc)
        {
            try
            {
                var _lc = db.LoaiCas.FirstOrDefault(x => x.MaLoaiCa == lc.MaLoaiCa);
                if (_lc != null)
                {
                    _lc.TenLoaiCa = lc.TenLoaiCa;
                    _lc.HeSo = lc.HeSo;
                    _lc.update_by = lc.update_by;
                    _lc.update_by = lc.update_by;
                    db.SaveChanges();
                }
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật LoaiCa: {ex.Message}");
            }
        }

        public void Delete(string maloaica, string iduser)
        {
            try
            {
                var _lc = db.LoaiCas.FirstOrDefault(x => x.MaLoaiCa == maloaica);
                if (_lc != null)
                {
                    _lc.delete_by = iduser;
                    _lc.delete_date = DateTime.Now;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa LoaiCa: {ex.Message}");
            }
        }
    }
}
