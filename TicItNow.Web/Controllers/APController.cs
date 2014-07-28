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
    public class APController : Controller
    {
        private TICDataContext db = new TICDataContext();

        //
        // GET: /AP/

        public ActionResult Index()
        {
            var analysisparams = db.AnalysisParams.Include(a => a.Unit).Include(a => a.Symbol);
            return View(analysisparams.ToList());
        }

        //
        // GET: /AP/Details/5

        public ActionResult Details(int id = 0)
        {
            AnalysisParam analysisparam = db.AnalysisParams.Find(id);
            if (analysisparam == null)
            {
                return HttpNotFound();
            }
            return View(analysisparam);
        }

        //
        // GET: /AP/Create

        public ActionResult Create()
        {
            ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Name");
            ViewBag.SymbolId = new SelectList(db.Symbols, "SymbolId", "Name");
            return View();
        }

        //
        // POST: /AP/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnalysisParam analysisparam)
        {
            if (ModelState.IsValid)
            {
                db.AnalysisParams.Add(analysisparam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Name", analysisparam.UnitId);
            ViewBag.SymbolId = new SelectList(db.Symbols, "SymbolId", "Name", analysisparam.SymbolId);
            return View(analysisparam);
        }

        //
        // GET: /AP/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AnalysisParam analysisparam = db.AnalysisParams.Find(id);
            if (analysisparam == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Name", analysisparam.UnitId);
            ViewBag.SymbolId = new SelectList(db.Symbols, "SymbolId", "Name", analysisparam.SymbolId);
            return View(analysisparam);
        }

        //
        // POST: /AP/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnalysisParam analysisparam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(analysisparam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Name", analysisparam.UnitId);
            ViewBag.SymbolId = new SelectList(db.Symbols, "SymbolId", "Name", analysisparam.SymbolId);
            return View(analysisparam);
        }

        //
        // GET: /AP/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AnalysisParam analysisparam = db.AnalysisParams.Find(id);
            if (analysisparam == null)
            {
                return HttpNotFound();
            }
            return View(analysisparam);
        }

        //
        // POST: /AP/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnalysisParam analysisparam = db.AnalysisParams.Find(id);
            db.AnalysisParams.Remove(analysisparam);
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