using System;
using System.ComponentModel.DataAnnotations;

namespace PreventDeskTool.Models
{
    public class Chat
    {
        [Key]

        public int ChatId { get; set; }

        public string MessageText { get; set; }

        public DateTime MessageTime { get; set; }

        public int UserId { get; set; }

    }
}
