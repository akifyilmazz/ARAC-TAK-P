using AracSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracSistem.Controllers
{
    public class AccountController : Controller
    {
        #region Giris Ekrani
        public ActionResult Login()
        {
            return View("Login/Login");
        }
        #endregion

        #region Post Giris Ekrani
        [HttpPost]
        public ActionResult Login(GirisModel login)
        {
            if (login.thisNull)
            {
                ViewBag.hata = "Boş Değer Girmeyiniz";
                return RedirectToAction("Login", "Account");
            }

            if(login.kullaniciAdi =="akif" && login.password == "akif")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.hata = "Yanlış Bilgi";
                return RedirectToAction("Login","Account");
            }
            
        }
        #endregion

        #region Yeni Kullanici
        public ActionResult CreatAccount()
        {
            return View();
        }
        #endregion
    }
}