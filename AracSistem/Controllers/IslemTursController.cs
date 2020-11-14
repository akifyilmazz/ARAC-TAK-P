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
    public class IslemTursController : Controller
    {
        private DbModel db = new DbModel();

        // GET: IslemTur
        public ActionResult Index(int sayfa = 0)
        {
            int toplamKayit = db.IslemTur.Count();
            var IslemTur = db.IslemTur.OrderBy(x => x.IslemTur_Id).Skip(10 / 1 * sayfa).Take(10).ToList();

            ViewResult<IslemTur> IslemTurler = new ViewResult<IslemTur>()
            {
                toplamKayit = toplamKayit,
                Veri = IslemTur,
                aktifSayfa = sayfa
            };
            return View(IslemTurler);
        }

        // GET: IslemTur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IslemTur IslemTur = db.IslemTur.Find(id);
            if (IslemTur == null)
            {
                return HttpNotFound();
            }
            return View(IslemTur);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(IslemTur IslemTur)
        {
            db.IslemTur.Add(IslemTur);
            db.SaveChanges();

            return Json(IslemTur);
        }
        [HttpGet]
        public ActionResult Edit(int? IslemTur_Id)
        {
            var IslemTur = db.IslemTur.Find(IslemTur_Id);

            return View("Edit", IslemTur);
        }
        [HttpPost]
        public JsonResult Edit(IslemTur b)
        {
            var IslemTur = db.IslemTur.Find(b.IslemTur_Id);
            IslemTur.IslemTur_Ad = b.IslemTur_Ad;
            db.SaveChanges();
            return Json(b);
        }
        [HttpPost]
        public JsonResult Delete(int? IslemTur_Id)
        {
            var hata = "";
            var islemTur = db.IslemTur.Find(IslemTur_Id);

            if (islemTur.Fatura.Count() == 0)
            {
                db.IslemTur.Remove(islemTur);
                db.SaveChanges();
            }
            else
            {
                hata = "Bu işlem Tür ile kesilmiş faturalar silinmesi gerekiyor !";
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
