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
            var fatura = db.Fatura.OrderByDescending(x => x.Fatura_Id).Skip(10 / 1 * sayfa).Take(10).ToList();

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

            InvcociesDetail invociesDetail = new InvcociesDetail();
            invociesDetail.Faturas = db.Fatura.Find(id);
            invociesDetail.Stok_Islems = db.Stok_Islem.Where(x => x.Fatura_Id == id).ToList();
            return View(invociesDetail);
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
            db.SaveChanges();
            Stok_Islem stokIslem = new Stok_Islem();
            for (int i = 0; i < faturaBilg.Stok_Islems.Count(); i++)
            {
                stokIslem.Fatura_Id = faturaBilg.Fatura[0].Fatura_Id;
                stokIslem.Stok_Id = faturaBilg.Stok_Islems[i].Stok_Id;
                stokIslem.IslemTur_Id = faturaBilg.Fatura[0].IslemTur_Id;
                stokIslem.StokIslem_Miktar = faturaBilg.Stok_Islems[0].StokIslem_Miktar;
                stokIslem.StokIslem_Tarih = faturaBilg.Fatura[0].Fatura_Tarih;
                stokIslem.StokIslem_Tutar = faturaBilg.Stok_Islems[i].StokIslem_Tutar;
                db.Stok_Islem.Add(stokIslem);
                db.SaveChanges();
            }
            Musteri_Islem musteriIslem = new Musteri_Islem();
            musteriIslem.Musteri_Id = faturaBilg.Musteri[0].Musteri_Id;
            musteriIslem.MusteriIslem_Tutar = Convert.ToInt32(faturaBilg.Fatura[0].Fatura_Tutar);
            musteriIslem.MusteriIslem_Kilometre = faturaBilg.Arac_Islems[0].AracIslem_Km;
            musteriIslem.MusteriIslem_Tarih = faturaBilg.Fatura[0].Fatura_Tarih;
            db.Musteri_Islem.Add(musteriIslem);
            db.SaveChanges();
            var gonder = faturaBilg.Fatura[0].Fatura_Id;
            return Json(gonder);
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
        public JsonResult Edit(NewInvociesSales faturaBilg)
        {
            var aracIslem = db.Arac_Islem.Find(faturaBilg.Arac_Islems[0].AracIslem_Id);
            aracIslem.Arac_Id = faturaBilg.Arac_Islems[0].Arac_Id;
            aracIslem.AracIslem_Km = faturaBilg.Arac_Islems[0].AracIslem_Km;
            aracIslem.AracIslem_Aciklama = faturaBilg.Arac_Islems[0].AracIslem_Aciklama;

            var fatura = db.Fatura.Find(faturaBilg.Fatura[0].Fatura_Id);
            fatura.IslemTur_Id = faturaBilg.Fatura[0].IslemTur_Id;
            fatura.OdemeSekli_Id = faturaBilg.Fatura[0].OdemeSekli_Id;
            fatura.AracIslem_Id = aracIslem.AracIslem_Id;
            fatura.Fatura_Tarih = faturaBilg.Fatura[0].Fatura_Tarih;
            fatura.Fatura_Tutar = faturaBilg.Fatura[0].Fatura_Tutar;
            fatura.Fatura_Aciklama = faturaBilg.Fatura[0].Fatura_Aciklama;

            Musteri_Islem musteriIslemm = new Musteri_Islem();
            var musId = Convert.ToInt32(faturaBilg.Musteri[0].Musteri_Id);
            musteriIslemm = db.Musteri_Islem.Where(x=>x.Musteri_Id == musId).FirstOrDefault();
            musteriIslemm.Musteri_Id = faturaBilg.Musteri[0].Musteri_Id;
            musteriIslemm.MusteriIslem_Tutar =Convert.ToInt32(faturaBilg.Fatura[0].Fatura_Tutar);
            musteriIslemm.MusteriIslem_Kilometre = faturaBilg.Arac_Islems[0].AracIslem_Km;
            musteriIslemm.MusteriIslem_Tarih = faturaBilg.Fatura[0].Fatura_Tarih;

            //eski stokları düzenliyor

            List<Stok_Islem> EskiStokIslem = new List<Stok_Islem>();
            var fatId = Convert.ToInt32(faturaBilg.Fatura[0].Fatura_Id);
            EskiStokIslem = db.Stok_Islem.Where(x => x.Fatura_Id == fatId).ToList();
            for (int i = 0; i < EskiStokIslem.Count(); i++)
            {
                db.Stok_Islem.Remove(EskiStokIslem[i]);//eski stok islemi siliyor
                db.SaveChanges();
                EskiStokIslem[i].Stok_Id = faturaBilg.Stok_Islems[i].Stok_Id;
                EskiStokIslem[i].Fatura_Id = faturaBilg.Fatura[0].Fatura_Id;
                EskiStokIslem[i].IslemTur_Id = faturaBilg.Fatura[0].IslemTur_Id;
                EskiStokIslem[i].StokIslem_Miktar = faturaBilg.Stok_Islems[i].StokIslem_Miktar;
                EskiStokIslem[i].StokIslem_Tarih = faturaBilg.Fatura[0].Fatura_Tarih;
                EskiStokIslem[i].StokIslem_Tutar= faturaBilg.Stok_Islems[i].StokIslem_Tutar;
                db.Stok_Islem.Add(EskiStokIslem[i]);
                db.SaveChanges();
            }

           
            return Json(faturaBilg);
        }

        [HttpPost]
        public ActionResult stokEklePartialView(int a ,int b)
        {
            stokEklePartialView StokEklePartial = new stokEklePartialView();
            StokEklePartial.Stoks = db.Stok.Where(x => x.Stok_Id == b).FirstOrDefault();
            StokEklePartial.RandSay = a;
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
