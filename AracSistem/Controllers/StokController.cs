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
    public class StokController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Stok
        public ActionResult Index()
        {
            var stok = db.Stok.ToList();
            return View(stok);
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
        
            return View();
        }

        [HttpPost]
        public JsonResult Create(Stok stok)
        {
            db.Stok.Add(stok);
            db.SaveChanges();
            return Json(stok);
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
