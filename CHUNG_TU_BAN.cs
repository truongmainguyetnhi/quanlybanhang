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
    
    public partial class CHUNG_TU_BAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUNG_TU_BAN()
        {
            this.CHUNG_TU_BAN_CT = new HashSet<CHUNG_TU_BAN_CT>();
        }
    
        public int ID_CTBAN { get; set; }
        public string MASOCT { get; set; }
        public Nullable<System.DateTime> NGAYDATHANG { get; set; }
        public Nullable<int> ID_KHACHHANG { get; set; }
        public Nullable<decimal> TONGTIENHANG { get; set; }
        public Nullable<double> THUE { get; set; }
        public Nullable<decimal> TIENTHUE { get; set; }
        public Nullable<decimal> TONGCONG { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
        public string GHICHU { get; set; }
        public Nullable<int> ID_THONGKE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUNG_TU_BAN_CT> CHUNG_TU_BAN_CT { get; set; }
        public virtual KY_THONG_KE KY_THONG_KE { get; set; }
        public virtual KHACH_HANG KHACH_HANG { get; set; }
    }
}
