﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BTLMonLTTQEntities : DbContext
    {
        public BTLMonLTTQEntities()
            : base("name=BTLMonLTTQEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaoHiem> BaoHiems { get; set; }
        public virtual DbSet<ChiTietDuAn> ChiTietDuAns { get; set; }
        public virtual DbSet<ChiTietKhoaDaoTao> ChiTietKhoaDaoTaos { get; set; }
        public virtual DbSet<ChiTietKT_KL> ChiTietKT_KL { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DaoTao> DaoTaos { get; set; }
        public virtual DbSet<DuAn> DuAns { get; set; }
        public virtual DbSet<HopDongLaoDong> HopDongLaoDongs { get; set; }
        public virtual DbSet<KT_KL> KT_KL { get; set; }
        public virtual DbSet<LichSuHoatDong> LichSuHoatDongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuLuong> PhieuLuongs { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<SoYeuLyLich> SoYeuLyLiches { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<LoaiCa> LoaiCas { get; set; }
        public virtual DbSet<LoaiCong> LoaiCongs { get; set; }
        public virtual DbSet<KYCONGCHITIET> KYCONGCHITIETs { get; set; }
        public virtual DbSet<KYCONG> KYCONGs { get; set; }
        public virtual DbSet<BANGCONG_NHANVIEN_CHITIET> BANGCONG_NHANVIEN_CHITIET { get; set; }
    }
}
