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
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.NowShowings == null)
            {
                return NotFound();
            }

            var ns = await _context.NowShowings
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (ns == null)
            {
                return NotFound();
            }

            return View(ns);
        }
        public async Task<IActionResult> Create()
        {
            //var data = await (from mov in _context.Movies
            //                      join hal in _context.Halls on mov.MovieId equals hal.MovieId
            //                      join sft in _context.Shifts on hal.HallId equals sft.HallId
            //                      select new MovieHallDTO
            //                      {
            //                          Occupancy = "",
            //                          MovieName = mov.MovieName,
            //                          MovieDescription = mov.Description,
            //                          HallName = hal.HallName,
            //                          ShiftTime = sft.ShitTime
            //                      }).ToListAsync();

            var movieNames = await _context.Movies
                .Select(m => new SelectListItem
                {
                    Value = m.MovieName,
                    Text = m.MovieName
                }).ToListAsync();

            var descNames = await _context.Movies
           .Select(m => new SelectListItem
           {
               Value = m.Description,
               Text = m.Description
           }).ToListAsync();

            var hallNames = await _context.Halls
              .Select(m => new SelectListItem
              {
                  Value = m.HallName,
                  Text = m.HallName
              }).ToListAsync();

            var shifts = await _context.Shifts
             .Select(m => new SelectListItem
             {
                 Value = m.ShitTime,
                 Text = m.ShitTime
             }).ToListAsync();

            var viewModel = new MoviesDropDownViewModel
            {
                Occupancy = "",
                MovieOptions = movieNames,
                HallOptions = hallNames,
                ShiftOptions = shifts,
                DescriptionOptions = descNames,
                MovieHallDTO = new MovieHallDTO()
            };
            return View(viewModel);



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MoviesDropDownViewModel viewModel)
        {
            //if (ModelState.IsValid)
            //{
            var nowShowing = new NowShowing
            {

                Occupancy = viewModel.Occupancy,
                MovieName = viewModel.MovieHallDTO.MovieName,
                MovieDescription = viewModel.MovieHallDTO.MovieDescription,
                HallName = viewModel.MovieHallDTO.HallName,
                ShiftTime = viewModel.MovieHallDTO.ShiftTime
            };

            _context.Add(nowShowing);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            //return View(viewModel); }
        }
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.NowShowings == null)
            {
                return NotFound();
            }

            var ns = await _context.NowShowings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ns == null)
            {
                return NotFound();
            }

            return View(ns);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (string id,NowShowing nowShowing)
        {
            if (id != nowShowing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nowShowing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NowShowingExists(nowShowing.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nowShowing);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.NowShowings == null)
            {
                return NotFound();
            }

            var ns = await _context.NowShowings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ns == null)
            {
                return NotFound();
            }

            return View(ns);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NowShowings == null)
            {
                return Problem("Entity set 'MovieManagementMVCContext.NowShowings'  is null.");
            }
            var ns = await _context.NowShowings.FindAsync(id);
            if (ns != null)
            {
                _context.NowShowings.Remove(ns);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool NowShowingExists(string id)
        {
            return (_context.NowShowings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


