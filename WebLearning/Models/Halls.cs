using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManagementMVC.Models
{
    public class Halls
    {
        [Key]
        public int HallId { get; set; }

        [Display(Name ="Hall Name")]
        public string HallName { get; set; } = string.Empty;


        [ForeignKey("Movies")]
        public int MovieId { get; set; }
        public Movies Movies;

        [Display(Name = "Hall Description")]
        public string HallDescription { get; set;} = string.Empty;
    }
}
