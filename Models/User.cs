using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreventDeskTool.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
   
        public string PhoneNo { get; set; }

    }
}
