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
    
    public partial class The
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public The()
        {
            this.GiaoDiches = new HashSet<GiaoDich>();
        }
    
        public int MaThe { get; set; }
        public string MatKhau { get; set; }
        public string TenChuThe { get; set; }
        public System.DateTime NgayHetHan { get; set; }
        public double SoDuKhaDung { get; set; }
        public int NganHang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaoDich> GiaoDiches { get; set; }
        public virtual NganHang NganHang1 { get; set; }
    }
}
