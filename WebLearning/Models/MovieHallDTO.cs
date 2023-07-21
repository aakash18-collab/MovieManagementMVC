using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManagementMVC.Models
{

    [NotMapped]
    public class MovieHallDTO : NowShowing
    {
        
        public string Occupancy { get; set; }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }

        public int HallId { get; set; }
        public string HallName { get; set; }

        public int ShiftId { get; set; }
        public string ShiftTime { get; set; }
    }
}


