using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreventDeskTool.Models
{
    public class Videos
    {
        [Key]
        public int VideoId { get; set; }

        public string VideoName { get; set; }

        public string VideoPath { get; set; }

        public string VideoSize { get; set; }

        public int DifficultyCategory { get; set; }

        [NotMapped]
        public int TotalVideos { get; set; }

    }
}
