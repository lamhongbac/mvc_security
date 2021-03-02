using MVCSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSecurity.Controllers
{
    [MyAuthorization(MyKeys = "user")]
    public class AdminFuncitonController : Controller
    {
        // GET: AdminFunciton
        public ActionResult Index()
        {
            return View();
        }
    }
}