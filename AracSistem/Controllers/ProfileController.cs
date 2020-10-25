using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AracSistem.Models;


namespace AracSistem.Controllers
{
    public class ProfileController : Controller
    {

        private DbModel db = new DbModel();

        public ActionResult Index()
        {
            var user = db.User.Find(1);
            return View(user);
        }
        [HttpPost]
        public JsonResult Index(User u)
        {
            var user = db.User.Find(u.User_Id);
            user.User_UserAd = u.User_UserAd;
            user.User_Mail = u.User_Mail;
            user.User_Sifre = u.User_Sifre;
            user.User_telefon = u.User_telefon;
            db.SaveChanges();   

            return Json(u);
        }
    }
}