using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSecurity.Models
{
    public class SecurityHandler
    {
        public UserAccount Login(string userName, string pwd,bool OK)
        {
            if (OK)
            {
                UserAccount account = new UserAccount();
                account.UserName = userName;
                account.Roles = new List<string>() {  "user" };
                return account;
            }
            else
                return null;
        }

        internal string[] GetUserRoles(string username)
        {
            if (HttpContext.Current!=null && HttpContext.Current.Session["User"]!=null)
            {
                UserAccount account =(UserAccount) HttpContext.Current.Session["User"];
                if (account.UserName == username)
                {
                    return account.Roles.ToArray();
                }
                else
                    return new string[0];
            }
            else
            {
                return new string[0];

            }
        }
    }
}