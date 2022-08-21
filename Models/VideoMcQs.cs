using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreventDeskTool.Models
{
    public class VideoMcQs
    {
        [Key]
        public int OptionId { get; set; }

        public string OptionText { get; set; }

        public int OptionPercentage { get; set; }

        [ForeignKey("Videos")]
        public int VideoId { get; set; }
        public DateTime CreatedDate { get; set; }        


       
    }
}
