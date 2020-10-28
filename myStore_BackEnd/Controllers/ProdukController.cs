using System;
using System.Collections.Generic;
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
            ViewData["view_produk"] = db.view_all_produk.ToList();
            ViewData["breadcrumbs"] = "Dashboard / Produk";
            return View();
        }
    }
}