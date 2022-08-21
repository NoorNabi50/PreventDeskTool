using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreventDeskTool.Models
{
    public class Chat
    {
        [Key]

        public int ChatId { get; set; }

        public string MessageText { get; set; }

        public DateTime MessageTime { get; set; }

        public int UserId { get; set; }
        public int AdminId { get; set; }

        public string MessageBy { get; set; }

        [NotMapped]
        public string MessageDate { get; set; }

        [NotMapped]
        public string UserName { get; set; }

        [NotMapped]
        public string AdminName { get; set; }



    }
}
