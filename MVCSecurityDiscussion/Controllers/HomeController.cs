using MVCSecurityDiscussion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSecurityDiscussion.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// ong ke nay chi xuat hien khi login la admin
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles ="admin")]
        public ActionResult AdditionalFunction()
        {
            return View();
        }
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult IndexAdmin()
        {
            return View();
        }
        [debugAuthorize(ORGs = "saomai,msa")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        /// <summary>
        /// moi nguoi deu thay o nay
        /// nhung user click vao se bao loi
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles ="admin,supper")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult EveryOneCanSee()
        {
            return View();
        }
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}