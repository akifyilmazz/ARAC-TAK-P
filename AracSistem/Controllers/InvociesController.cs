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
                stokIslem.Fatura_Id = faturaBilg.Fatura[0].Fatura_Id;
                stokIslem.Stok_Id = faturaBilg.Stoks[i].Stok_Id;
                stokIslem.IslemTur_Id = faturaBilg.Fatura[0].IslemTur_Id;
                stokIslem.StokIslem_Miktar = 1;
                stokIslem.StokIslem_Tarih = faturaBilg.Fatura[0].Fatura_Tarih;
                db.Stok_Islem.Add(stokIslem);
                db.SaveChanges();
            }
            Musteri_Islem musteriIslem = new Musteri_Islem();
            musteriIslem.Musteri_Id = faturaBilg.Musteri[0].Musteri_Id;
            musteriIslem.MusteriIslem_Tutar = Convert.ToInt32(faturaBilg.Fatura[0].Fatura_Tutar);
            musteriIslem.MusteriIslem_Kilometre = faturaBilg.Arac_Islems[0].AracIslem_Km;
            musteriIslem.MusteriIslem_Tarih = faturaBilg.Fatura[0].Fatura_Tarih;
            return Json(faturaBilg);
        }

        public ActionResult Edit(int? Fatura_Id)
        {
            InvociesEdit Edit = new InvociesEdit();
            Edit.Fatura = db.Fatura.Where(x => x.Fatura_Id == Fatura_Id).FirstOrDefault();
            Edit.Stok_Islems = db.Stok_Islem.Where(x => x.Fatura_Id == Fatura_Id).ToList();
            var musteriId= Edit.Fatura.Arac_Islem.Arac.Ruhsat.Musteri.Musteri_Id;
            Edit.Musteri = db.Musteri.Where(x => x.Musteri_Id == musteriId).FirstOrDefault();
            Edit.Musteri_Islems = db.Musteri_Islem.Where(x => x.Musteri_Id == musteriId).FirstOrDefault();
            var aracId = Edit.Fatura.Arac_Islem.Arac.Arac_Id;
            Edit.Arac_Islems = db.Arac_Islem.Where(x => x.Arac_Id == aracId).FirstOrDefault();
            Edit.OdemeSeklis = db.OdemeSekli.ToList();
            Edit.Aracs = db.Arac.ToList();
            Edit.Stoks = db.Stok.ToList();
            Edit.IslemTurs = db.IslemTur.ToList();
            return View(Edit);
        }

        [HttpPost]
        public ActionResult stokEklePartialView(int a)
        {
            stokEklePartialView StokEklePartial = new stokEklePartialView();
            StokEklePartial.Stoks = db.Stok.Where(x => x.Stok_Id == a).FirstOrDefault();
            Random rnd = new Random();
            StokEklePartial.RandSay = rnd.Next(30);
            return PartialView(StokEklePartial);
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
