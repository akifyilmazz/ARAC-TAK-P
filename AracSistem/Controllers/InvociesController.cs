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

        public ActionResult Index(int sayfa = 0)
        {
            int toplamKayit = db.Fatura.Count();
            var fatura = db.Fatura.OrderBy(x => x.Fatura_Id).Skip(10 / 1 * sayfa).Take(10).ToList();

            ViewResult<Fatura> faturalar = new ViewResult<Fatura>()
            {
                toplamKayit = toplamKayit,
                Veri = fatura,
                aktifSayfa = sayfa
            };

            return View(faturalar);
        }


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
            var stokIslem = sonuc.IslemTur.Stok_Islem.ToList();
            return View(sonuc);
        }

        public ActionResult Create()
        {
            var musteri = db.Musteri.ToList();
            return View(musteri);
        }

        public ActionResult NewInvoiceSales(int? musteri_Id)
        {
            FaturaCreat FaturaCreats = new FaturaCreat();
            {
                FaturaCreats.Musteris = db.Musteri.Where(x => x.Musteri_Id == musteri_Id).First();
                FaturaCreats.Arac_Islems = db.Arac_Islem.ToList();
                FaturaCreats.IslemTurs = db.IslemTur.ToList();
                FaturaCreats.OdemeSeklis = db.OdemeSekli.ToList();
                FaturaCreats.Stoks = db.Stok.ToList();
                FaturaCreats.Aracs = db.Arac.Where(x => x.Ruhsat.Musteri_Id == musteri_Id).ToList();
            }
            return View(FaturaCreats);
        }


        [HttpPost]
        public JsonResult NewInvoiceSales(NewInvociesSales faturaBilg)
        {
            db.Arac_Islem.Add(faturaBilg.Arac_Islems[0]);
            faturaBilg.Fatura[0].AracIslem_Id = faturaBilg.Arac_Islems[0].AracIslem_Id;

            db.Fatura.Add(faturaBilg.Fatura[0]);

            Stok_Islem stokIslem = new Stok_Islem();
            for (int i = 0; i < faturaBilg.Stoks.Count(); i++)
            {
                stokIslem.Stok_Id = faturaBilg.Stoks[i].Stok_Id;
                stokIslem.IslemTur_Id = faturaBilg.Fatura[0].IslemTur_Id;
                stokIslem.StokIslem_Miktar = 1;
                stokIslem.StokIslem_Tarih = faturaBilg.Fatura[0].Fatura_Tarih;
                db.Stok_Islem.Add(stokIslem);
                db.SaveChanges();
            }

            return Json(faturaBilg);
        }

        [HttpPost]
        public ActionResult Test(int a)
        {
            var stok = db.Stok.Where(x => x.Stok_Id == a).FirstOrDefault();
            return PartialView(stok);
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
