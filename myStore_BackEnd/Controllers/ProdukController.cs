using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using myStore_BackEnd.Models;

namespace myStore_BackEnd.Controllers
{
    public class ProdukController : Controller
    {
        mystoreEntities db = new mystoreEntities();

        public ActionResult Index()
        {
            ViewData["kategori"] = db.kategoris.ToList();
            ViewData["view_produk"] = db.view_all_produk.ToList();
            ViewData["breadcrumbs"] = "Dashboard / Produk";
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(FormCollection fv)
        {
            try
            {
                produk pd = new produk();
                pd.id_kategori = int.Parse(fv["id_kategori"]);
                pd.kode_produk = fv["kode_produk"];
                pd.nama_produk = fv["nama_produk"];
                pd.keterangan = fv["keterangan"];
                pd.harga = Convert.ToDecimal(fv["harga"]);
                pd.stok = int.Parse(fv["stok"]);
                pd.gambar = fv["stok"];

                // Untuk Gambar
                string path, filename, renameName = "";
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    path = Path.Combine(Server.MapPath("~/Content/images/"), "");
                    var pathSave = Path.Combine(Directory.GetCurrentDirectory(), path);

                    if (file != null && file.ContentLength > 0)
                    {
                        filename = Path.GetFileName(file.FileName);
                        renameName = fv["kode_produk"] + "." + filename.Split('.').Last();
                        var fullPath = Path.Combine(pathSave, renameName);
                        file.SaveAs(fullPath);
                        pd.gambar = "~/Content/images/" + renameName;
                    }
                }

                db.produks.Add(pd);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult DeleteProduk(int id)
        {
            try
            {
                var produk = db.produks.SingleOrDefault(p => p.id_produk == id);
                if(produk != null)
                {
                    ProdukModel pm = new ProdukModel();
                    string filename = pm.GetFileGambar(id);
                    db.produks.Remove(produk);
                    db.SaveChanges();
                    if (System.IO.File.Exists(Server.MapPath(filename)))
                    {
                        System.IO.File.Delete(Server.MapPath(filename));            
                    }   
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditProduk(int id)
        {
            var pd = db.produks.SingleOrDefault(p => p.id_produk == id);
            ViewData["kategori"] = db.kategoris.ToList();

            return View("Edit", pd);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(FormCollection fv, produk prd) {
            try
            {
                if (ModelState.IsValid)
                {
                    var pd = db.produks.SingleOrDefault(p => p.id_produk == prd.id_produk);

                    if(pd != null)
                    {
                        pd.id_kategori = int.Parse(fv["id_kategori"]);
                        pd.kode_produk = fv["kode_produk"];
                        pd.nama_produk = fv["nama_produk"];
                        pd.keterangan = fv["keterangan"];
                        pd.harga = Convert.ToDecimal(fv["harga"]);
                        pd.stok = int.Parse(fv["stok"]);

                        // Untuk Gambar
                        string path, filename, renameName = "";
                        if (Request.Files.Count > 0)
                          {
                            // TODO : Cek File Gambar dan Hapus File Gambar Lama

                            var file = Request.Files[0];
                            path = Path.Combine(Server.MapPath("~/Content/images/"), "");
                            var pathSave = Path.Combine(Directory.GetCurrentDirectory(), path);

                            if (file != null && file.ContentLength > 0)
                            {
                                filename = Path.GetFileName(file.FileName);
                                renameName = fv["kode_produk"] + "." + filename.Split('.').Last();
                                var fullPath = Path.Combine(pathSave, renameName);
                                file.SaveAs(fullPath);
                                pd.gambar = "~/Content/images/" + renameName;
                            }
                        }

                        db.SaveChanges();
                    }
                }                                                                                                       
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}