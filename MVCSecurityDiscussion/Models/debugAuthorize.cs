using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSecurityDiscussion.Models
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class debugAuthorize: AuthorizeAttribute
    {
        public string ORGs { get; set; }
        /// <summary>
        /// ham nay chay truocde xac dinh co authorize hay kg
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string user = Users;
            bool kq= base.AuthorizeCore(httpContext);
            //msapptech --> user
            string useOrg = "msapptech";
            if (ORGs.Split(',').Contains(useOrg))
            {
                return true;
            }
            else
                return false;
          //  return kq;
        }
        /// <summary>
        /// ham nay chay trong khi authorization\
        /// xu ly neu authorizw thi lam gi, va kg autho thi lam gi
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Home/AccessDenied");
                return;
            }

        }
    }
    
}