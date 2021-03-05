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
        public ActionResult IndexUser()
        {
            ViewBag.UserName = User.Identity.Name;

            return View();
        }
        /// <summary>
        /// gia su day la action method xu ly cho hanh dong approval
        /// only admin with approval
        /// chu y Roles/Users la thuoc tinh mac dinh cua Authorize class
        /// Right la thuoc tinh them vao trong CustomAuthorization
        /// Roles va User value dc set tu command duoi day/ tu chinh filter nay
        /// can cu vao httpContext.User==> lay ra gia tri can so sanh thi du nhu lay ra
        /// user nay co role la user va right= view
        /// lop CustomAuthorize se so sanh voi cac thuoc tinh Role/Users/Right de return false
        /// tu choi su dung 
        /// 
        /// </summary>
        /// <returns></returns>
        [CustomAuthorize(Roles = "admin" , Rights ="approval" )]
        [HttpPost]
        public ActionResult AdvanceObject()
        {
            return View();
        }
        [CustomAuthorize(Roles = "User")]
        public ActionResult AboutUser()
        {
            return View();
        }

        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            if (!User.IsInRole("User") )
            {
                return RedirectToAction("AboutUser", "Home");
            }
            else
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
                ModelState.AddModelError("",
             "The user name or password provided is incorrect.");
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