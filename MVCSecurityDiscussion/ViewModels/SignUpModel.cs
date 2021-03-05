using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSecurityDiscussion.ViewModels
{
    public class SignUpModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
    }
}