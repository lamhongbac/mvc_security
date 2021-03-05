using MVCSecurityDiscussion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCSecurityDiscussion.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModel model,string ReturnUrl)
        {

            if (model.UserName == "test")
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                var authTicket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(20),
                    model.RememberMe, "");

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                if (ReturnUrl != null)
                    return Redirect(ReturnUrl);
                else return RedirectToAction("Index", "Home");
            }
            else if (model.UserName == "bac")
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                var authTicket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(20),
                    model.RememberMe, "");

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                if (ReturnUrl != null)
                    return Redirect(ReturnUrl);
                else return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username/password");
                return View(model);
            }
        }

        //[HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}