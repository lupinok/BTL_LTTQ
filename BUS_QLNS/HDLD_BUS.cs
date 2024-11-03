using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class HDLD_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public HopDongLaoDong getItem(int mhd)
        {
            return db.HopDongLaoDongs.FirstOrDefault(x => x.MaHopDong == mhd);
        }
        public List<HopDongLaoDong> getList()
        {
            return db.HopDongLaoDongs.ToList();
        }
        public List<HDLDDTO> getListFull()
        {
            List<HopDongLaoDong> lst = db.HopDongLaoDongs.ToList();
            List<HDLDDTO> lstDTO = new List<HDLDDTO>();
            HDLDDTO hd;
            foreach (var item in lst)
            {
                hd = new HDLDDTO();
                // Map thông tin hợp đồng
                hd.MaHopDong = item.MaHopDong;
                hd.LoaiHopDong = item.LoaiHopDong;
                hd.NgayBatDau = item.NgayBatDau;
                hd.NgayKetThuc = item.NgayKetThuc;
                hd.LuongHopDong = item.LuongHopDong;
                hd.NoiDungHopDong = item.NoiDungHopDong;
                hd.MaNhanVien = item.MaNhanVien;
                hd.TenBaoHiem = item.TenBaoHiem;
                hd.MucDong = item.MucDong;

                // Map thông tin nhân viên
                var nv = db.NhanViens.FirstOrDefault(n => n.MaNhanVien == hd.MaNhanVien);
                hd.HoTen = nv.HoTen;
                hd.create_date = item.create_date;
                hd.update_by = item.update_by;
                lstDTO.Add(hd);
            } 
            return lstDTO;
        }
        public HopDongLaoDong Add(HopDongLaoDong lc)
        {
            try
            {
                var exists = db.HopDongLaoDongs.FirstOrDefault(x =>
                x.MaHopDong == lc.MaHopDong);

                if (exists != null)
                    throw new Exception("Đã tồn tại bản ghi này cho nhân viên.");
                db.HopDongLaoDongs.Add(lc);
                db.SaveChanges();
                return lc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }


        public HopDongLaoDong Update(HopDongLaoDong lc)
        {
            try
            {
                var _lc = db.HopDongLaoDongs.FirstOrDefault(x => x.MaHopDong == lc.MaHopDong);
                if (_lc != null)
                {
                    _lc.MaNhanVien = lc.MaNhanVien;
                    _lc.MaHopDong = lc.MaHopDong;
                    _lc.LoaiHopDong = lc.LoaiHopDong;
                    _lc.NgayBatDau = lc.NgayBatDau;
                    _lc.NgayKetThuc = lc.NgayKetThuc;
                    _lc.LuongHopDong = lc.LuongHopDong;
                    _lc.TenBaoHiem = lc.TenBaoHiem;
                    _lc.MucDong = lc.MucDong;
                    _lc.NoiDungHopDong = lc.NoiDungHopDong;
                    _lc.create_date = lc.create_date;
                    _lc.update_by = lc.update_by;
                }

                        
                db.SaveChanges();
                        
                return lc;
                  
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật HopDongLaoDongs: {ex.Message}");
            }
        }
        public bool KiemTraTrung(int maNV, int mahd)
        {
            try
            {
                // Kiểm tra xem đã tồn tại bản ghi nào thỏa mãn các điều kiện
                var check = db.HopDongLaoDongs.FirstOrDefault(x =>
                    x.MaNhanVien == maNV &&
                    x.MaHopDong == mahd);

                return check != null; // Trả về true nếu đã tồn tại, false nếu chưa tồn tại
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra trùng: " + ex.Message);
            }
        }
        public void Delete(int mpc)
        {
            try
            {
                var _lc = db.HopDongLaoDongs.FirstOrDefault(x => x.MaHopDong == mpc);
                if (_lc != null)
                {
                    db.HopDongLaoDongs.Remove(_lc);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa HopDongLaoDongs: {ex.Message}");
            }
        }
    }
}
