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
    public class HomeController : Controller
    {
        //
        // GET: /Home/
      private TICDataContext db = new TICDataContext();


      [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

      [HttpPost]
      public ActionResult Index(string userName, string passWord)
      {
        return View();
      }

        public ActionResult Report()
        {
          var analysisparams = db.AnalysisParams.Include(a => a.Unit).Include(a => a.Symbol);
          return View(analysisparams.ToList());
        }

    }
}
