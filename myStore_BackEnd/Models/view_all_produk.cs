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
    
    public partial class view_all_produk
    {
        public int id { get; set; }
        public string keterangan { get; set; }
        public int id_produk { get; set; }
        public string kode_produk { get; set; }
        public string nama_kategori { get; set; }
        public Nullable<decimal> harga { get; set; }
        public Nullable<int> stok { get; set; }
        public string gambar { get; set; }
        public string nama_produk { get; set; }
    }
}