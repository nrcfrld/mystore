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
    
    public partial class view_transaksi
    {
        public int id_transaksi_detail { get; set; }
        public Nullable<int> id_transaksi { get; set; }
        public Nullable<int> id_produk { get; set; }
        public string nama_produk { get; set; }
        public Nullable<int> jumlah { get; set; }
        public Nullable<decimal> harga { get; set; }
        public Nullable<decimal> JumlahUang { get; set; }
    }
}
