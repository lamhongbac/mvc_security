using MVCSecurityDiscussion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public ActionResult Login(AccountModel model, string ReturnUrl)
        {

            if (model.UserName == "test" || model.UserName == "bac")
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                Session["UserName"] = model.UserName;

                var roles = ConvertRoleToString(Roles.GetRolesForUser(model.UserName));
                //var userName = User.Identity.Name;

                var authTicket = new FormsAuthenticationTicket(1, model.UserName, 
                    DateTime.Now, DateTime.Now.AddMinutes(20),
                     model.RememberMe, roles);

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

        private string ConvertRoleToString(string[] v)
        {
            int i = 0;
            StringBuilder roles = new StringBuilder();
            foreach (string item in v)
            {
                if (i > 0)
                {
                    roles.Append(",");
                }
                roles.Append(item);
                i++;

            }
            return roles.ToString();
        }

        //[HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpModel model)
        {
            //if model is valid
            return RedirectToAction("Login");
        }
    }
}