//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webbanhang
{
    using System;
    using System.Collections.Generic;
    
    public partial class HANG_HOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANG_HOA()
        {
            this.CHUNG_TU_BAN_CT = new HashSet<CHUNG_TU_BAN_CT>();
            this.CHUNG_TU_MUA_CT = new HashSet<CHUNG_TU_MUA_CT>();
            this.DON_GIA_BAN = new HashSet<DON_GIA_BAN>();
            this.THUOC_TINH = new HashSet<THUOC_TINH>();
        }
    
        public int ID_HANGHOA { get; set; }
        public string TENHANGHOA { get; set; }
        public string MOTA { get; set; }
        public string DONVITINH { get; set; }
        public byte[] HINHANH { get; set; }
        public Nullable<int> ID_PHANLOAI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUNG_TU_BAN_CT> CHUNG_TU_BAN_CT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUNG_TU_MUA_CT> CHUNG_TU_MUA_CT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_GIA_BAN> DON_GIA_BAN { get; set; }
        public virtual PHAN_LOAI PHAN_LOAI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUOC_TINH> THUOC_TINH { get; set; }
    }
}