using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MVCSecurity.Models
{
    public class UserAccount
    {
        public string UserID { get; set; }
        public UserAccount()
        {
            Roles = new List<string>();
        }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }

        public string RoleList
        {
            get
            {
                return Compose(Roles);
            }
        }

        private string Compose(List<string> roles)
        {
            int i = 0;
            StringBuilder rolename = new StringBuilder();
            foreach (var item in roles)
            {
                if (i > 0)
                {
                    rolename.Append(",");
                    rolename.Append(item);
                }
                else
                {
                    rolename.Append(item);

                }
                i++;

            }
            return rolename.ToString();
        }
    }

    public enum EUserType
    {
        Admin,
        User
    }
}