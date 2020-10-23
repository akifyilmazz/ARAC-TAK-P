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
    public class CustomerController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Customer
        public ActionResult Index()
        {
            var Customer = db.Musteri.ToList();
            return View(Customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            var sonuc = db.Ruhsat.Where(x => x.Musteri_Id == musteri.Musteri_Id).FirstOrDefault();
                
            return View(sonuc);
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
