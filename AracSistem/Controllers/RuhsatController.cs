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
    public class RuhsatController : Controller
    {
        private DbModel db = new DbModel();

        public ActionResult Index(int sayfa = 0)
        {
            int toplamKayit = db.Ruhsat.Count();
            var ruhsat = db.Ruhsat.OrderByDescending(x => x.Ruhsat_Id).Skip(10 / 1 * sayfa).Take(10).ToList();

            ViewResult<Ruhsat> ruhsatlar = new ViewResult<Ruhsat>()
            {
                toplamKayit = toplamKayit,
                Veri = ruhsat,
                aktifSayfa = sayfa
            };

            return View(ruhsatlar);
        }

        // GET: Ruhsat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruhsat ruhsat = db.Ruhsat.Find(id);
            if (ruhsat == null)
            {
                return HttpNotFound();
            }
            return View(ruhsat);
        }

        public ActionResult Create()
        {
            RuhsatCreat ruhsatCreat = new RuhsatCreat();
            ruhsatCreat.Musteris = db.Musteri.ToList();
            return View(ruhsatCreat);
        }

        [HttpPost]
        public JsonResult Create(Ruhsat ruhsat)
        {
            db.Ruhsat.Add(ruhsat);
            var result = db.SaveChanges();
            return Json(result);
        }

        public ActionResult Edit(int? Ruhsat_Id)
        {
            RuhsaEdit ruhsatEdit = new RuhsaEdit();
            ruhsatEdit.Ruhsats = db.Ruhsat.Where(x => x.Ruhsat_Id == Ruhsat_Id).FirstOrDefault();
            ruhsatEdit.Musteris = db.Musteri.ToList();
            return View(ruhsatEdit);
        }
        [HttpPost]
        public JsonResult Edit(Ruhsat r)
        {
            var ruhsat = db.Ruhsat.Find(r.Ruhsat_Id);
            ruhsat.Musteri_Id = r.Musteri_Id;
            ruhsat.Ruhsat_EklenmeTarih = r.Ruhsat_EklenmeTarih;
            ruhsat.Ruhsat_No = r.Ruhsat_No;
            db.SaveChanges();
            return Json(r);
        }

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            var hata = "";
            var ruhsat = db.Ruhsat.Find(id);

            if (ruhsat.Arac.Count() == 0)
            {
                db.Ruhsat.Remove(ruhsat);
                db.SaveChanges();
            }
            else
            {
                hata = "Buruhsata ait Araçların silinmesi gerekiyor !";
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
