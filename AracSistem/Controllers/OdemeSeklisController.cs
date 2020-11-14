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
    public class OdemeSeklisController : Controller
    {
        private DbModel db = new DbModel();

        // GET: odemeSekli
        public ActionResult Index(int sayfa = 0)
        {
            int toplamKayit = db.OdemeSekli.Count();
            var odemeSekli = db.OdemeSekli.OrderBy(x => x.OdemeSekli_Id).Skip(10 / 1 * sayfa).Take(10).ToList();

            ViewResult<OdemeSekli> odemeSekliler = new ViewResult<OdemeSekli>()
            {
                toplamKayit = toplamKayit,
                Veri = odemeSekli,
                aktifSayfa = sayfa
            };
            return View(odemeSekliler);
        }

        // GET: OdemeSeklis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeSekli odemeSekli = db.OdemeSekli.Find(id);
            if (odemeSekli == null)
            {
                return HttpNotFound();
            }
            return View(odemeSekli);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(OdemeSekli odemeSekli)
        {
            db.OdemeSekli.Add(odemeSekli);
            db.SaveChanges();

            return Json(odemeSekli);
        }
        [HttpGet]
        public ActionResult Edit(int? OdemeSekli_Id)
        {
            var odemeSekli = db.OdemeSekli.Find(OdemeSekli_Id);

            return View("Edit", odemeSekli);
        }
        [HttpPost]
        public JsonResult Edit(OdemeSekli o)
        {
            var odemeSekli = db.Birim.Find(o.OdemeSekli_Id);
            odemeSekli.Birim_Ad = o.OdemeSekli_Ad;
            db.SaveChanges();
            return Json(o);
        }
        public JsonResult Delete(int? id)
        {
            var hata = "";
            var odemeSekli = db.OdemeSekli.Find(id);

            if (odemeSekli.Fatura.Count() == 0)
            {
                db.OdemeSekli.Remove(odemeSekli);
                db.SaveChanges();
            }
            else
            {
                hata = "Bu ödeme Şekli ile kesilmiş faturalar silimesi gerekiyor !";
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
