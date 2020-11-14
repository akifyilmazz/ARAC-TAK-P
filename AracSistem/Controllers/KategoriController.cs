﻿using System;
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
    public class KategoriController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Kategori
        public ActionResult Index(int sayfa = 0)
        {
            int toplamKayit = db.Kategori.Count();
            var kategori = db.Kategori.OrderBy(x => x.Kategori_Id).Skip(10 / 1 * sayfa).Take(10).ToList();

            ViewResult<Kategori> kategoriler = new ViewResult<Kategori>()
            {
                toplamKayit = toplamKayit,
                Veri = kategori,
                aktifSayfa = sayfa
            };


            return View(kategoriler);
        }

        // GET: Kategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Kategori kategori)
        {
            db.Kategori.Add(kategori);
            db.SaveChanges();

            return Json(kategori);
        }

        [HttpGet]
        public ActionResult Edit(int? Kategori_Id)
        {
            var kategori = db.Kategori.Find(Kategori_Id);

            return View("Edit", kategori);
        }
        [HttpPost]
        public JsonResult Edit(Kategori k)
        {
            var kategori = db.Kategori.Find(k.Kategori_Id);
            kategori.Kategori_Ad = k.Kategori_Ad;
            db.SaveChanges();
            return Json(k);
        }
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            var hata = "";
            var kategori = db.Kategori.Find(id);

            if (kategori.Stok.Count() == 0)
            {
                db.Kategori.Remove(kategori);
                db.SaveChanges();
            }
            else
            {
                hata = "Bu Kategori İle Seçilmiş Faturalar silinmesi gerekiyor !";
            }
            return Json(hata);
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
