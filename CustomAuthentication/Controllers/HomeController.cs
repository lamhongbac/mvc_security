using CustomAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CustomAuthentication.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;

            return View();
        }

        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountModel model, string ReturnUrl)
        {
            if (model.Username == "test" && model.Password == "test")
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
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("Index");
        }

        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}