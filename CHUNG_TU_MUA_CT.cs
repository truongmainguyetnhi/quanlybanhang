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
    
    public partial class CHUNG_TU_MUA_CT
    {
        public int ID_CT { get; set; }
        public Nullable<int> ID_HANGHOA { get; set; }
        public Nullable<decimal> GIAMUA { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<decimal> THANHTIEN { get; set; }
        public Nullable<int> ID_CTMUA { get; set; }
    
        public virtual CHUNG_TU_MUA CHUNG_TU_MUA { get; set; }
        public virtual HANG_HOA HANG_HOA { get; set; }
    }
}