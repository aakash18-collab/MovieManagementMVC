using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManagementMVC.Data;
using MovieManagementMVC.Models;
using System.Collections;
using System.Collections.Generic; 

namespace MovieManagementMVC.Controllers
{
    public class NowShowingController : Controller
    {
        private readonly MovieManagementMVCContext _context;
      

        public NowShowingController(MovieManagementMVCContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return _context.NowShowings != null ?
                        View(await _context.NowShowings.ToListAsync()) :
                        Problem("Entity set 'MovieManagementMVCContext.NowShowings'  is null.");
           
        }
        public async Task<IActionResult> Create()
        {

            var data = await (from mov in _context.Movies
                              join hal in _context.Halls on mov.MovieId equals hal.MovieId
                              join sft in _context.Shifts on hal.HallId equals sft.HallId
                              select new MovieHallDTO
                              {
                                  Occupancy = "",
                                  MovieId = mov.MovieId,
                                  MovieName = mov.MovieName,
                                  MovieDescription = mov.Description,
                                  HallId = hal.HallId,
                                  HallName = hal.HallName,
                                  ShiftId = sft.ShitId,
                                  ShiftTime = sft.ShitTime
                              }).ToListAsync();

            //var model = new NowShowing
            //{
            //    Movies = data
            //};
            var movieItems = data.Select(movie => new SelectListItem
            {
                Value = movie.MovieId.ToString(),
                Text = movie.MovieName
            });
            ViewBag.MovieName = movieItems;
            //ViewBag.MovieName = new SelectList(data, "MovieId", "MovieName");
            var movieDesc = data.Select(movie => new SelectListItem
            {
                Value = movie.MovieId.ToString(),
                Text = movie.MovieDescription
            });
            ViewBag.MovieDescription = movieDesc;
            //ViewBag.MovieDescription = new SelectList(data, "MovieId", "MovieDescription");
            var hallName = data.Select(movie => new SelectListItem
            {
                Value = movie.HallId.ToString(),
                Text = movie.HallName
            });
            ViewBag.HallName = hallName;
            //ViewBag.HallName = new SelectList(data, "HallId", "HallName");
            var shiftTime = data.Select(movie => new SelectListItem
            {
                Value = movie.ShiftId.ToString(),
                Text = movie.ShiftTime
            });
            ViewBag.ShiftTime = shiftTime;
            //ViewBag.ShiftTime = new SelectList(data, "ShiftId", "ShiftTime");

            return View();
            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Occupancy,MovieName,MovieDescription,HallName,ShiftTime")] NowShowing nowShowing)
        {

            if (ModelState.IsValid)
            {
                _context.Add(nowShowing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nowShowing);
        }

    }

  
}
