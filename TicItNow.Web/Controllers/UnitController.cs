﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicItNow.Web.Models;

namespace TicItNow.Web.Controllers
{
    public class UnitController : Controller
    {
        private TICDataContext db = new TICDataContext();

        //
        // GET: /Unit/

        public ActionResult Index()
        {
            return View(db.Units.ToList());
        }

        //
        // GET: /Unit/Details/5

        public ActionResult Details(int id = 0)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        //
        // GET: /Unit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Unit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        //
        // GET: /Unit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        //
        // POST: /Unit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        //
        // GET: /Unit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        //
        // POST: /Unit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}