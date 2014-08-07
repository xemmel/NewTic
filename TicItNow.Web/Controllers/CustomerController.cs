using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicItNow.Web.Models;

namespace TicItNow.Web.Controllers
{
    public class CustomerController : Controller
    {
      private TICDataContext db = new TICDataContext();

        //
        // GET: /Customer/
            [Authorize]

        public ActionResult Index()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public ActionResult Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
