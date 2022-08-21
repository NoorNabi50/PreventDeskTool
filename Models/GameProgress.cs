using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreventDeskTool.Models
{
    public class GameProgress
    {
        [Key]

        public int ProgressId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [NotMapped]
        public List<GameProgressDetail> gameProgressDetail { get; set; }

        [NotMapped]
        public GameProgressVideo gameProgressVideo { get; set; }
    }
}
