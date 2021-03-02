using MVCSecurity.Models;
using MVCSecurity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSecurity.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountViewModel model)
        {
            SecurityHandler securityHandler = new SecurityHandler();
           UserAccount account= securityHandler.Login(model.UserName, model.Password,true);
            if (account!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index");

        }
    }
}