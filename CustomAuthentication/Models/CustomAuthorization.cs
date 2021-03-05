using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomAuthentication.Models
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isAuthorized= base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            if (Users.Split(',').Contains(httpContext.User.Identity.Name))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// edit,add,view,delete
        /// </summary>
        public string Rights { get; set; }
        /// <summary>
        /// khi kg thoa dieu kien authorization
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    filterContext.Result = new RedirectResult("~/Account/Index");
            //    return;
            //}
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Home/AccessDenied");
                return;
            }

        }

    }
}