using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicItNow.Web.Models;

namespace TicItNow.Web.Controllers
{
    public class SymbolController : Controller
    {
        private TICDataContext db = new TICDataContext();

        //
        // GET: /Symbol/

        public ActionResult Index()
        {
            return View(db.Symbols.ToList());
        }

        //
        // GET: /Symbol/Details/5

        public ActionResult Details(int id = 0)
        {
            Symbol symbol = db.Symbols.Find(id);
            if (symbol == null)
            {
                return HttpNotFound();
            }
            return View(symbol);
        }

        //
        // GET: /Symbol/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Symbol/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Symbol symbol)
        {
            if (ModelState.IsValid)
            {
                db.Symbols.Add(symbol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(symbol);
        }

        //
        // GET: /Symbol/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Symbol symbol = db.Symbols.Find(id);
            if (symbol == null)
            {
                return HttpNotFound();
            }
            return View(symbol);
        }

        //
        // POST: /Symbol/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Symbol symbol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(symbol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(symbol);
        }

        //
        // GET: /Symbol/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Symbol symbol = db.Symbols.Find(id);
            if (symbol == null)
            {
                return HttpNotFound();
            }
            return View(symbol);
        }

        //
        // POST: /Symbol/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Symbol symbol = db.Symbols.Find(id);
            db.Symbols.Remove(symbol);
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