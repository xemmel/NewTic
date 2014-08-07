using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TicItNow.Web.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /Auth/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
         
          return View();
        }
       
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(string userName, string passWord)
        {
          if (passWord.ToLower().Contains("clara"))
          {
            FormsAuthentication.SetAuthCookie(userName, true);
            return RedirectToAction("Index", "Home");
          }
          else
          {
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View();

          }
        }

        public ActionResult LogOut()
        {
          if (User.Identity.IsAuthenticated)
          {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
          }
          else
          {
            return RedirectToAction("LogIn", "Auth");

          }
        }

    }
}
