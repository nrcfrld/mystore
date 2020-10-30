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
    }
}