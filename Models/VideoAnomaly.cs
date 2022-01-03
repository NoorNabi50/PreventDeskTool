using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreventDeskTool.Models
{
    public class VideoAnomaly
    {
        [Key]
        public int AnomalyId { get; set; }

        public decimal AnomalyInterval { get; set; }

        [ForeignKey("Videos")]
        public int VideoId { get; set; }
        public DateTime CreatedDate { get; set; }        


       
    }
}
