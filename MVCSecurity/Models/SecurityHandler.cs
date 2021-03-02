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
                account.Roles = new List<string>() { "Admin", "User" };
                return account;
            }
            else
                return null;
        }
    }
}