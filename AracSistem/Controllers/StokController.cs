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
    public class StokController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Stok
        public ActionResult Index(int sayfa = 0)
        {
            int toplamKayit = db.Stok.Count();
            var stok = db.Stok.OrderBy(x => x.Stok_Id).Skip(10/1*sayfa).Take(10).ToList();
            
            ViewResult<Stok> stoklar = new ViewResult<Stok>()
            {
                toplamKayit = toplamKayit,
                Veri = stok,
                aktifSayfa=sayfa
            };

            return View(stoklar);
        }

        // GET: Stok/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stok.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            return View(stok);
        }

        public ActionResult Create()
        {
            StokCreate stokCreate = new StokCreate();
            stokCreate.Birims = db.Birim.ToList();
            stokCreate.Kategoris = db.Kategori.ToList();
            return View(stokCreate);
        }

        [HttpPost]
        public JsonResult Create(Stok stok)
        {
            db.Stok.Add(stok);
            var result = db.SaveChanges();
            return Json(result);
        }
        [HttpGet]
        public ActionResult Edit(int? Stok_Id)
        {
            var stok = db.Stok.Find(Stok_Id);

            return View("Edit", stok);
        }
        [HttpPost]
        public JsonResult Edit(Stok s)
        {
            var stok = db.Stok.Find(s.Stok_Id);
            stok.Kategori_Id = s.Kategori_Id;
            stok.Birim_Id = s.Birim_Id;
            stok.Stok_Barkod = s.Stok_Barkod;
            stok.Stok_Ad = s.Stok_Ad;
            stok.Stok_AlisFiyat = s.Stok_AlisFiyat;
            stok.Stok_SatisFiyat = s.Stok_SatisFiyat;
            stok.Stok_KdvOran = s.Stok_KdvOran;
            stok.Stok_OtvOran = s.Stok_OtvOran;
            db.SaveChanges();
            return Json(s);
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
