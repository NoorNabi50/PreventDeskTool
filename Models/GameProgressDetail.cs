using System.ComponentModel.DataAnnotations;

namespace PreventDeskTool.Models
{
    public class GameProgressDetail
    {

        [Key]

        public int GameProgressDetailId { get; set; }

        public int GameProgressVideoId { get; set; }

        public int OptionValue { get; set; }
       


    }
}
