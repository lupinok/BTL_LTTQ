using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class HDLDDTO
    {
        public int MaHopDong { get; set; }
        public string LoaiHopDong { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public Nullable<decimal> LuongHopDong { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
        public string HoTen { set; get; }
        public string TenBaoHiem { get; set; }

        public Nullable<decimal> MucDong { get; set; }
        public string NoiDungHopDong { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public string update_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public string delete_by { get; set; }
        public Nullable<System.DateTime> delete_date { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
