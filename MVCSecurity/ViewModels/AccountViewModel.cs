using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSecurity.ViewModels
{
    public class AccountViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}