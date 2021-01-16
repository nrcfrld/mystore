using myStore_BackEnd.App_Code;
using myStore_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myStore_BackEnd.Controllers
{
    [GlobalSession]
    public class TransaksiController : Controller
    {
        mystoreEntities db = new mystoreEntities();
        // GET: Transaksi
        public ActionResult Index(int? idtrans)
        {

            List<transaksi_header> headers;
            var idcustomer = 0;
            var iddetail = 0;
            ViewData["produk"] = db.produks.ToList();
            if (idtrans != null)
            {
                headers = db.transaksi_header.Where(p => p.id_transaksi == idtrans).ToList();
                foreach (var dt in (dynamic)headers)
                {
                    idcustomer = dt.id_customer;
                    iddetail = dt.id_transaksi;
                }
                ViewData["customer"] = db.customers.Where(c => c.id_customer == idcustomer).ToList();
                ViewData["details"] = db.view_transaksi.Where(d => d.id_transaksi == idtrans).ToList();
            }
            else
            {
                headers = db.transaksi_header.ToList();
                ViewData["customer"] = db.customers.ToList();
                ViewData["details"] = db.view_transaksi.Where(d => d.id_transaksi == 0).ToList(); ;
            }
            ViewData["headers"] = headers;
            return View();
        }

        public ActionResult ResultDetailView(int? id)
        {
            var details = (from e in db.view_transaksi where (id == null || e.id_transaksi == id) select e).ToList();

            ViewData["view_details"] = details;
            return PartialView("Details");
        }

        [HttpGet]
        public JsonResult getHargaProduk(int? id)
        {
            decimal hp = 0;
            string nama = "";
            var pd = db.produks.SingleOrDefault(p => p.id_produk == id);
            hp = Convert.ToDecimal(pd.harga);
            nama = pd.nama_produk;
            return Json(new { nama_produk = nama, harga = hp }, JsonRequestBehavior.AllowGet);
        }
    }
}