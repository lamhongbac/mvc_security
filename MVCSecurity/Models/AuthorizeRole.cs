using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSecurity.Models
{
    public enum Role
    {
        SUPERADMIN = 1,
        ADMIN = 2,
        USER = 3,
    }
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// object[] roles dc truyen tu controller lay gia tri cua thuoc tinh
        /// ben trong constructor [AuthorizeRole(Role.SUPERADMIN)]
        /// </summary>
        /// <param name="roles"></param>
        public AuthorizeRoleAttribute(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("roles");
            this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Account/Index");
                return;
            }
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Home/AccessDenied");
                return;
            }
        }
    }
}