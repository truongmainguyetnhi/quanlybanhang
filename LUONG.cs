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
    
    public partial class LUONG
    {
        public int ID_LUONG { get; set; }
        public int ID_NHAN_VIEN { get; set; }
        public Nullable<int> HESO { get; set; }
        public Nullable<decimal> DONGIA { get; set; }
        public Nullable<int> SONGAYNGHICOPHEP { get; set; }
        public Nullable<int> SONGAYNGHIKHONGPHEP { get; set; }
        public Nullable<int> TONGNGAYLAM { get; set; }
        public Nullable<decimal> TONGLUONG { get; set; }
    
        public virtual NHAN_VIEN NHAN_VIEN { get; set; }
    }
}