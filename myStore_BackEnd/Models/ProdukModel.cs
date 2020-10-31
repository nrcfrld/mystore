using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;

namespace myStore_BackEnd.Models
{
    public class ProdukModel
    {
        mystoreEntities db = new mystoreEntities();

        public string GetFileGambar(int id) {
            string foto = "";
            var cari = db.produks.Where(a => a.id_produk == id).FirstOrDefault();
            
            if(cari != null)
            {
                foto = cari.gambar;
            }
            return foto;
        }
    }
}