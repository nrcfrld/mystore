using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace myStore_BackEnd.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult doLogin()
        {
            if (ModelState.IsValid)
            {
                Models.AccountModel db = new Models.AccountModel();
                string uid = Request.Form["loginUsername"];

                MD5 md5 = new MD5CryptoServiceProvider();
                Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(Request.Form["loginPassword"]);
                Byte[] encodedBytes = md5.ComputeHash(originalBytes);
                string pwd = BitConverter.ToString(encodedBytes).Replace("-", "");

                string user_level = db.getLogin(uid, pwd);
                Session["title"] = "myStore";
                if(user_level == "")
                {
                    Session["user_id"] = null;
                    Session["user_level"] = null;
                    ViewBag.Message = "Invalid Login";
                    return RedirectToAction("Index", "Login");
                }

                Session["user_id"] = uid;
                Session["user_level"] = user_level;
                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult LogOff()
        {
            Session["user_id"] = null;
            Session["user_level"] = null;
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}