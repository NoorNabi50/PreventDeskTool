using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreventDeskTool.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
   
        public string PhoneNo { get; set; }

        public bool IsRemember { get; set; }
        public string Role { get; set; }

    
    }
}
