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
    public class HallsController : Controller
    {
        private readonly MovieManagementMVCContext _context;

        public HallsController(MovieManagementMVCContext context)
        {
            _context = context;
        }

        // GET: Halls
        public async Task<IActionResult> Index()
        {
              return _context.Halls != null ? 
                          View(await _context.Halls.ToListAsync()) :
                          Problem("Entity set 'MovieManagementMVCContext.Halls'  is null.");
        }

        // GET: Halls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Halls == null)
            {
                return NotFound();
            }

            var halls = await _context.Halls
                .FirstOrDefaultAsync(m => m.HallId == id);
            if (halls == null)
            {
                return NotFound();
            }

            return View(halls);
        }

        // GET: Halls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Halls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HallId,HallName,MovieId,HallDescription")] Halls halls)
        {
            if (ModelState.IsValid)
            {
                _context.Add(halls);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(halls);
        }

        // GET: Halls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Halls == null)
            {
                return NotFound();
            }

            var halls = await _context.Halls.FindAsync(id);
            if (halls == null)
            {
                return NotFound();
            }
            return View(halls);
        }

        // POST: Halls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HallId,HallName,MovieId,HallDescription")] Halls halls)
        {
            if (id != halls.HallId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(halls);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HallsExists(halls.HallId))
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
            return View(halls);
        }

        // GET: Halls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Halls == null)
            {
                return NotFound();
            }

            var halls = await _context.Halls
                .FirstOrDefaultAsync(m => m.HallId == id);
            if (halls == null)
            {
                return NotFound();
            }

            return View(halls);
        }

        // POST: Halls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Halls == null)
            {
                return Problem("Entity set 'MovieManagementMVCContext.Halls'  is null.");
            }
            var halls = await _context.Halls.FindAsync(id);
            if (halls != null)
            {
                _context.Halls.Remove(halls);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HallsExists(int id)
        {
          return (_context.Halls?.Any(e => e.HallId == id)).GetValueOrDefault();
        }
    }
}
