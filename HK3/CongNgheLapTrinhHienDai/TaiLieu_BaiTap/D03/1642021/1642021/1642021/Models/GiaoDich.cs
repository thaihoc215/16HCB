//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1642021.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GiaoDich
    {
        public int MaGiaoDich { get; set; }
        public int TaiKhoan { get; set; }
        public int NganHangSoHu { get; set; }
        public double SoTienGiaoDich { get; set; }
        public System.DateTime ThoiDiemGiaoDich { get; set; }
        public int LoaiGiaoDich { get; set; }
    
        public virtual The The { get; set; }
        public virtual The The1 { get; set; }
        public virtual The The2 { get; set; }
        public virtual LoaiGiaoDich LoaiGiaoDich1 { get; set; }
        public virtual LoaiGiaoDich LoaiGiaoDich2 { get; set; }
        public virtual LoaiGiaoDich LoaiGiaoDich3 { get; set; }
    }
}
