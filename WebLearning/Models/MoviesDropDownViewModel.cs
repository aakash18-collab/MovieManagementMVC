using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieManagementMVC.Models
{
    public class MoviesDropDownViewModel
    {
        // public string Occupancy { get; set; }
        //public IEnumerable<SelectListItem> MovieOptions { get; set; }

        // public IEnumerable<SelectListItem> HallOptions { get; set; }

        // public IEnumerable<SelectListItem> ShiftOptions { get; set; }


        //public IEnumerable<SelectListItem> DescriptionOptions { get; set; }
        //public MovieHallDTO MovieHallDTO { get; set; }

        public string Occupancy { get; set; }

            // Add an additional option for static text at the beginning of each dropdown
            public IEnumerable<SelectListItem> MovieOptions { get; set; } = new List<SelectListItem>
             {
                  new SelectListItem { Value = "", Text = "Select a Movie" }
            };

            public IEnumerable<SelectListItem> HallOptions { get; set; } = new List<SelectListItem>
              {
                  new SelectListItem { Value = "", Text = "Select a Hall" }
                 };

            public IEnumerable<SelectListItem> ShiftOptions { get; set; } = new List<SelectListItem>
              {
              new SelectListItem { Value = "", Text = "Select a Shift" }
             };

            public IEnumerable<SelectListItem> DescriptionOptions { get; set; } = new List<SelectListItem>
             {
                new SelectListItem { Value = "", Text = "Select a Description" }
            };

            public MovieHallDTO MovieHallDTO { get; set; }
        

    }
}
