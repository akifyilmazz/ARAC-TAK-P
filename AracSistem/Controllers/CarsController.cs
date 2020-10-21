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
    public class CarsController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Cars
        public ActionResult Index()
        {
            var arac = db.Arac.ToList();
            return View(arac);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arac arac = db.Arac.Find(id);
            if (arac == null)
            {
                return HttpNotFound();
            }
            return View(arac);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(Arac arac)
        {
            db.Arac.Add(arac);
            db.SaveChanges();
            return Json(arac);
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
