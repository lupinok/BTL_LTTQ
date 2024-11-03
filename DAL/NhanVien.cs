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
    
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.ChiTietDuAns = new HashSet<ChiTietDuAn>();
            this.ChiTietKhoaDaoTaos = new HashSet<ChiTietKhoaDaoTao>();
            this.ChiTietKT_KL = new HashSet<ChiTietKT_KL>();
            this.HopDongLaoDongs = new HashSet<HopDongLaoDong>();
            this.PhieuLuongs = new HashSet<PhieuLuong>();
            this.PhuCaps = new HashSet<PhuCap>();
            this.TangCas = new HashSet<TangCa>();
            this.ThanhToans = new HashSet<ThanhToan>();
            this.UngLuongs = new HashSet<UngLuong>();
            this.NhanVienThoiViecs = new HashSet<NhanVienThoiViec>();
        }
    
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public Nullable<int> SoDienThoai { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> NgayBatDauLamViec { get; set; }
        public Nullable<int> MaPhongBan { get; set; }
        public Nullable<int> MaChucVu { get; set; }
        public Nullable<bool> DaThoiViec { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDuAn> ChiTietDuAns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietKhoaDaoTao> ChiTietKhoaDaoTaos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietKT_KL> ChiTietKT_KL { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDongLaoDong> HopDongLaoDongs { get; set; }
        public virtual PhongBan PhongBan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuLuong> PhieuLuongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhuCap> PhuCaps { get; set; }
        public virtual SoYeuLyLich SoYeuLyLich { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TangCa> TangCas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UngLuong> UngLuongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVienThoiViec> NhanVienThoiViecs { get; set; }
    }
}
