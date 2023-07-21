using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManagementMVC.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }

        [Display(Name = "Movie Name")]
        public string MovieName { get; set; } = string.Empty;

        [Display(Name = "Movie Description")]
        public string Description { get; set; } = string.Empty;
    }
}
