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
    
    public partial class THUOC_TINH
    {
        public int ID_THUOCTINH { get; set; }
        public string TEN { get; set; }
        public string GIATRI { get; set; }
        public byte[] HINHANH { get; set; }
        public Nullable<int> ID_HANGHOA { get; set; }
    
        public virtual HANG_HOA HANG_HOA { get; set; }
    }
}
