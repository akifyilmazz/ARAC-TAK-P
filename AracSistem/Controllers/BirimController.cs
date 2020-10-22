﻿using System;
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
    public class BirimController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Birim
        public ActionResult Index()
        {
            var birim = db.Birim.ToList();
            return View(birim);
        }

        // GET: Birim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birim birim = db.Birim.Find(id);
            if (birim == null)
            {
                return HttpNotFound();
            }
            return View(birim);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Birim birim)
        {
                db.Birim.Add(birim);
                db.SaveChanges();

            return Json(birim);
        }
        [HttpGet]
        public ActionResult Edit(int? Birim_Id)
        {
            var birim = db.Birim.Find(Birim_Id);

            return View("Edit", birim);
        }
        [HttpPost]
        public JsonResult Edit(Birim b)
        {
            var birim = db.Birim.Find(b.Birim_Id);
            birim.Birim_Ad = b.Birim_Ad;
            db.SaveChanges();
            return Json(b);
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
