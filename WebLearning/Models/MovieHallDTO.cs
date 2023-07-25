using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManagementMVC.Models
{
    public class MovieHallDTO 
    {
            public string Occupancy { get; set; } = "";
            public string MovieName { get; set; }
            public string MovieDescription { get; set; }
            public string HallName { get; set; }
            public string ShiftTime { get; set; }
        

    }
}


