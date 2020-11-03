using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AracSistem.Models;
using AracSistem.ViewModels;

namespace AracSistem.Controllers
{
    public class HomeController : Controller
    {
        private DbModel db = new DbModel();
        public ActionResult Index()
        {
            HomeIndex HomeIndex = new HomeIndex();

               HomeIndex.Musteris = db.Musteri.ToList();
               HomeIndex.Faturas = db.Fatura.ToList();
               HomeIndex.Stoks = db.Stok.ToList();
               HomeIndex.Aracs = db.Arac.ToList();
          
            return View(HomeIndex);
        }
    }
}