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
    
    public partial class KYCONG
    {
        public int ID { get; set; }
        public int MAKYCONG { get; set; }
        public Nullable<int> THANG { get; set; }
        public Nullable<int> NAM { get; set; }
        public Nullable<bool> KHOA { get; set; }
        public Nullable<System.DateTime> NGAYTINHCONG { get; set; }
        public Nullable<double> NGAYCONGTRONGTHANG { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public string update_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public string delete_by { get; set; }
        public Nullable<System.DateTime> delete_date { get; set; }
    }
}
