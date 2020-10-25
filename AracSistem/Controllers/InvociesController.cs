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
    public class InvociesController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Fatura
        public ActionResult Index(int sayfa = 0)
        {
            int toplamKayit = db.Fatura.Count();
            var fatura = db.Fatura.OrderBy(x => x.Fatura_Id).Skip(10 / 1 * sayfa).Take(10).ToList();

            ViewResult<Fatura> faturalar= new ViewResult<Fatura>()
            {
                toplamKayit = toplamKayit,
                Veri = fatura,
                aktifSayfa = sayfa
            };

            return View(faturalar);
        }

        // GET: Fatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Fatura.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            var sonuc = db.Fatura.Where(x => x.Fatura_Id == fatura.Fatura_Id).FirstOrDefault();
            return View(sonuc);
        }

        public ActionResult Create()
        {
            FaturaCreat faturaCreate = new FaturaCreat();
            faturaCreate.OdemeSeklis = db.OdemeSekli.ToList();
            faturaCreate.IslemTurs = db.IslemTur.ToList();
            return View(faturaCreate);
        }

        [HttpPost]
        public JsonResult Create(Fatura fatura)
        {
            db.Fatura.Add(fatura);
            db.SaveChanges();
            return Json(fatura);
        }

        [HttpGet]
        public ActionResult Edit(int? Fatura_Id)
        {
            var fatura = db.Fatura.Find(Fatura_Id);

            return View("Edit", fatura);
        }
        [HttpPost]
        public JsonResult Edit(Fatura ft)
        {
            var fatura = db.Fatura.Find(ft.Fatura_Id);
            fatura.IslemTur_Id = ft.IslemTur_Id;
            fatura.OdemeSekli_Id = ft.OdemeSekli_Id;
            fatura.AracIslem_Id = ft.AracIslem_Id;
            fatura.Fatura_Tarih = ft.Fatura_Tarih;
            fatura.Fatura_Tutar = ft.Fatura_Tutar;
            fatura.Fatura_Aciklama = ft.Fatura_Aciklama;
            db.SaveChanges();
            return Json(ft);
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
