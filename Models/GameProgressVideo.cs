using System.ComponentModel.DataAnnotations;

namespace PreventDeskTool.Models
{
    public class GameProgressVideo
    {
        [Key]

        public int GameProgressVideoId { get; set; }

        public int ProgressId { get; set; }

        public int VideoId { get; set; }
    }
}
