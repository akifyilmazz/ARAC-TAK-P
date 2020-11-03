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
    public class CustomerController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Customer
        public ActionResult Index(int sayfa = 0)
        {
            int toplamKayit = db.Musteri.Count();
            var musteri = db.Musteri.OrderBy(x => x.Musteri_Id).Skip(10 / 1 * sayfa).Take(10).ToList();

            ViewResult<Musteri> musteriler = new ViewResult<Musteri>()
            {
                toplamKayit = toplamKayit,
                Veri = musteri,
                aktifSayfa = sayfa
            };
            return View(musteriler);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            CustomerDetails CustomerDetais = new CustomerDetails();
            CustomerDetais.Musteris = db.Musteri.Where(x => x.Musteri_Id == id).FirstOrDefault();
            CustomerDetais.Ruhsats = db.Ruhsat.Where(x => x.Musteri_Id == id).ToList();
           
                
            return View(CustomerDetais);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Musteri musteri)
        {
            db.Musteri.Add(musteri);
            db.SaveChanges();
            return Json(musteri);
        }
        [HttpGet]
        public ActionResult Edit(int? Customer_Id)
        {
            var customer = db.Musteri.Find(Customer_Id);

            return View("Edit", customer);
        }
        [HttpPost]
        public JsonResult Edit(Musteri m)
        {
            var musteri = db.Musteri.Find(m.Musteri_Id);

            musteri.Musteri_AdSoyad = m.Musteri_AdSoyad;
            musteri.Musteri_Telefon= m.Musteri_Telefon;
         
            musteri.Musteri_Adres = m.Musteri_Adres;
            musteri.Musteri_CepTelefon = m.Musteri_CepTelefon;
            musteri.Musteri_Mail = m.Musteri_Mail;
            db.SaveChanges();
            return Json(m);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
