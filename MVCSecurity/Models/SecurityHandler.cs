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
                if (userName == "Bac")
                {
                    account.UserID = "200270";
                    account.Roles = new List<string>() { "USER" };
                }
                if (userName == "Supper")
                {
                    account.UserID = "210270";
                    account.Roles = new List<string>() { "USER","ADMIN", "SUPERADMIN" };
                }
                if (userName == "Admin")
                {
                    account.UserID = "220270";
                    account.Roles = new List<string>() { "USER", "ADMIN" };
                }
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