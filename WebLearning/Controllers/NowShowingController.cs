using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieManagementMVC.Data;
using MovieManagementMVC.Models;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

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

       
            ViewBag.MovieName = new SelectList(data, "MovieId","MovieName");
          
            ViewBag.MovieDescription = new SelectList(data, "MovieId", "MovieDescription");
           
            ViewBag.HallName = new SelectList(data, "HallId", "HallName");
           
            ViewBag.ShiftTime = new SelectList(data, "ShiftId",  "ShiftTime");

            #region notinuse
            //{
            //    Movies = data
            //};
            //var movieItems = data.Select(movie => new SelectListItem
            //{
            //    Value = movie.MovieId.ToString(),
            //    Text = movie.MovieName
            //});
            //ViewBag.MovieName = movieItems;
            //var movieDesc = data.Select(movie => new SelectListItem
            //{
            //    Value = movie.MovieId.ToString(),
            //    Text = movie.MovieDescription
            //});
            //ViewBag.MovieDescription = movieDesc;
            //var hallName = data.Select(movie => new SelectListItem
            //{
            //    Value = movie.HallId.ToString(),
            //    Text = movie.HallName
            //});
            //ViewBag.HallName = hallName;
            //var shiftTime = data.Select(movie => new SelectListItem
            //{
            //    Value = movie.ShiftId.ToString(),
            //    Text = movie.ShiftTime
            //});
            //ViewBag.ShiftTime = shiftTime;
            #endregion

            return View();
            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Create(MovieHallDTO movieHallDTO)
        {
            if (movieHallDTO == null)
            {
                return false;
            }
            NowShowing nowShowing = new NowShowing();
            nowShowing.Occupancy = movieHallDTO.Occupancy;
            nowShowing.MovieName = movieHallDTO.MovieName;
            nowShowing.MovieDescription= movieHallDTO.MovieDescription;
            nowShowing.HallName= movieHallDTO.HallName;
            nowShowing.ShiftTime = movieHallDTO.ShiftTime;
            _context.Add(nowShowing);
            _context.SaveChangesAsync();

            return true;
        }
        //public async Task <IActionResult>Create([Bind("Id,Occupancy,MovieName,MovieDescription,HallName,ShiftTime")] MovieHallDTO movieHallDTO)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(movieHallDTO);
        //         _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(movieHallDTO);
        //    /*return new List<MovieHallDTO>(movieHallDTO.ShiftTime.ToList());*/
        //}

    }

  
}
