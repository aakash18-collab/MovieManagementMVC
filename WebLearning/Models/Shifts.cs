using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManagementMVC.Models
{
    public class Shifts
    {
        [Key]
        public int ShitId { get; set; }

        

        [ForeignKey("Halls")]
        public int HallId { get; set; }
        public Halls Halls;

        [Display(Name = "Shift Time")]
        public string ShitTime { get; set; } = string.Empty;
    }
}
