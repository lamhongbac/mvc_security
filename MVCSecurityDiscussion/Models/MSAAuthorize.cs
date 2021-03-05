using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCSecurityDiscussion.Models
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class MSAAuthorize: AuthorizeAttribute
    {
        public string ORGs { get; set; }
        /// <summary>
        /// ham nay chay truocde xac dinh co authorize hay kg
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            bool isAuthorized = base.AuthorizeCore(httpContext);
            if (isAuthorized)
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    string encTicket = authCookie.Value;
                    if (!String.IsNullOrEmpty(encTicket))
                    {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encTicket);

                        var id = new UserIdentity(ticket);
                        string[] userRoles = ConvertToRoleArray(ticket.UserData);
                        var prin = new GenericPrincipal(id, userRoles);
                        HttpContext.Current.User = prin;
                    }
                }


                //return kq;
            }
            return isAuthorized;
        }
        private string[] ConvertToRoleArray(string userData)
        {
            return userData.Split(',');
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