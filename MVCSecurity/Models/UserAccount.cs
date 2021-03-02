using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSecurity.Models
{
    public class UserAccount
    {
        public UserAccount()
        {
            Roles = new List<string>();
        }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }

    }

    public enum EUserType
    {
        Admin,
        User
    }
}