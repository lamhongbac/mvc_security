using MVCSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSecurity.Controllers
{
    public class HomeController : Controller
    {
        //[AuthorizeRole(Role.SUPERADMIN, Role.ADMIN)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// AuthorizeRole la 1 class thua huong tu class AuthorizeAttribute
        /// AuthorizeRole(Role.SUPERADMIN): tuc la goi ham constructor voi tham so
        /// Role.SupperAdmin
        /// ket qua cua viec nay la tao ra lop authorized cho method co thuoc tinh roles la 
        /// la mang co 1 pan tu la "SuperAdmin"
        /// lop nay co  y nghia nhu 1 mang loc filter, de kiem tra nguoi login co role 
        /// trong danh sach roles thi moi cho di tiep
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles="SUPERADMIN")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles ="ADMIN,USER")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Roles="USER,ADMIN,SUPPERADMIN")]
        public ActionResult UserPage()
        {
            ViewBag.Message = "User Page";
            return View();
        }
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}