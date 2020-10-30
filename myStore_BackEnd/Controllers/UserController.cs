using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myStore_BackEnd.Models;

namespace myStore_BackEnd.Controllers
{
    public class UserController : Controller
    {
        mystoreEntities db = new mystoreEntities();
        // GET: Users
        public ActionResult Index()
        {
            ViewData["users"] = db.users.ToList();
            ViewData["breadcrumbs"] = "Dashboard / Users";
            return View();
        }
    }
}