using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManagementMVC.Data;
using MovieManagementMVC.Models;

namespace MovieManagementMVC.Controllers
{
    public class NowShowingsController : Controller
    {
        private readonly MovieManagementMVCContext _context;

        public NowShowingsController(MovieManagementMVCContext context)
        {
            _context = context;
        }

        // GET: NowShowings
        public async Task<IActionResult> Index()
        {
            return _context.NowShowing != null ?
                        View(await _context.NowShowing.ToListAsync()) :
                        Problem("Entity set 'MovieManagementMVCContext.NowShowing'  is null.");
            //NowShowing now = new NowShowing();
            //now.Movies = MoviesController();
            //now.Halls = HallsController();
            //return View(now);
        }

        // GET: NowShowings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NowShowing == null)
            {
                return NotFound();
            }

            var nowShowing = await _context.NowShowing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nowShowing == null)
            {
                return NotFound();
            }

            return View(nowShowing);
        }

        // GET: NowShowings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NowShowings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] NowShowing nowShowing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nowShowing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nowShowing);
        }

        // GET: NowShowings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NowShowing == null)
            {
                return NotFound();
            }

            var nowShowing = await _context.NowShowing.FindAsync(id);
            if (nowShowing == null)
            {
                return NotFound();
            }
            return View(nowShowing);
        }

        // POST: NowShowings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] NowShowing nowShowing)
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

        // GET: NowShowings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NowShowing == null)
            {
                return NotFound();
            }

            var nowShowing = await _context.NowShowing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nowShowing == null)
            {
                return NotFound();
            }

            return View(nowShowing);
        }

        // POST: NowShowings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NowShowing == null)
            {
                return Problem("Entity set 'MovieManagementMVCContext.NowShowing'  is null.");
            }
            var nowShowing = await _context.NowShowing.FindAsync(id);
            if (nowShowing != null)
            {
                _context.NowShowing.Remove(nowShowing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NowShowingExists(int id)
        {
          return (_context.NowShowing?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
