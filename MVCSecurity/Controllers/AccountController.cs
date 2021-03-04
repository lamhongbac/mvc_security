using MVCSecurity.Models;
using MVCSecurity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCSecurity.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Login view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// login button process (in LoginView)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(AccountViewModel model)
        {
            SecurityHandler securityHandler = new SecurityHandler();
           UserAccount account= securityHandler.Login(model.UserName, model.Password,true);
            if (account!=null)
            {

                FormsAuthentication.SetAuthCookie(account.UserName, model.IsRemember);
                FormsAuthentication.SetAuthCookie(Convert.ToString(account.UserID), model.IsRemember);
                var authTicket = new FormsAuthenticationTicket(1, account.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), 
                    false, account.RoleList);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                //Based on the Role we can transfer the user to different page
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Index", "Home");
            }
            return View("Index");

        }
        /// <summary>
        /// Log Out button process
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}