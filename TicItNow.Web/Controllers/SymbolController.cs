using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TicItNow.Web.Models;

namespace TicItNow.Web.Controllers
{

  public class SymbolApiController : System.Web.Http.ApiController
  {
    private TICDataContext db = new TICDataContext();


    // GET api/SymbolApi
    public IEnumerable<Symbol> GetSymbols()
    {
      return db.Symbols.AsEnumerable();
    }

    // GET api/SymbolApi/5
    public Symbol GetSymbol(int id)
    {
      Symbol symbol = db.Symbols.Find(id);
      if (symbol == null)
      {
        throw new System.Web.Http.HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
      }

      return symbol;
    }

    // PUT api/SymbolApi/5
    public HttpResponseMessage PutSymbol(int id, Symbol symbol)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      if (id != symbol.SymbolId)
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      db.Entry(symbol).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK);
    }

    // POST api/SymbolApi
    public HttpResponseMessage PostSymbol(Symbol symbol)
    {
      if (ModelState.IsValid)
      {
        db.Symbols.Add(symbol);
        db.SaveChanges();

        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, symbol);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = symbol.SymbolId }));
        return response;
      }
      else
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }
    }

    // DELETE api/SymbolApi/5
    public HttpResponseMessage DeleteSymbol(int id)
    {
      Symbol symbol = db.Symbols.Find(id);
      if (symbol == null)
      {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }

      db.Symbols.Remove(symbol);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK, symbol);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }


  public class SymbolController : Controller
  {
    private TICDataContext db = new TICDataContext();

    //
    // GET: /Symbol/SPAIndex
    public ActionResult SPAIndex()
    {
      return View();
    }

    //
    // GET: /Symbol
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