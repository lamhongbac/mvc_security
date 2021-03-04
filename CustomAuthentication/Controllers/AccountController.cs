using CustomAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CustomAuthentication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(AccountModel model,string ReturnUrl)
        {
            if (model.Username=="test" && model.Password=="test")
            {
                //authorized
                FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                if (ReturnUrl != null)
                    return Redirect(ReturnUrl);
                else return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model); 
            }

        }
    }
}