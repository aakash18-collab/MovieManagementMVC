using System;

namespace MovieManagementMVC.Models
{
    public class MovieDTO
    {
        public int SelectedMovieId { get; set; }
        public int SelectedHallId { get; set; }
        public int SelectedShiftId { get; set; }

        public IEnumerable<Movies> Movies { get; set; }
        public IEnumerable<Halls> Halls { get; set; }
        public IEnumerable<Shifts> Shifts { get; set; }
    }

}
