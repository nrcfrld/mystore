using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myStore_BackEnd.Models;

namespace myStore_BackEnd.Controllers
{
    public class KategoriController : Controller
    {
        mystoreEntities db = new mystoreEntities();

        // GET: Kategori
        public ActionResult Index()
        {
            ViewData["categories"] = db.kategoris.ToList();
            ViewData["breadcrumbs"] = "Dashboard / Kategori";

            return View();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var category = db.kategoris.SingleOrDefault(p => p.id == id);
                if (category != null)
                {
                    db.kategoris.Remove(category);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}