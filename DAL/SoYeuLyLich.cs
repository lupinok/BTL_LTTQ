//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SoYeuLyLich
    {
        public int MaNhanVien { get; set; }
        public string TrinhDoHocVan { get; set; }
        public string KinhNghiem { get; set; }
        public string KyNang { get; set; }
        public string ChungChi { get; set; }
        public string NgoaiNgu { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string GiaCanh { get; set; }
        public string HinhAnh { get; set; }
        public string QuocTich { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
