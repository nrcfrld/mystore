//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace myStore_BackEnd.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {
        public int id_customer { get; set; }
        public string nama_customer { get; set; }
        public string alamat { get; set; }
        public string telpon { get; set; }
        public string email { get; set; }
        public Nullable<int> status { get; set; }
        public string validasi_user { get; set; }
    }
}