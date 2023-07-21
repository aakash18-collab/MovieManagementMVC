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
    public class ShiftsController : Controller
    {
        private readonly MovieManagementMVCContext _context;

        public ShiftsController(MovieManagementMVCContext context)
        {
            _context = context;
        }

        // GET: Shifts
        public async Task<IActionResult> Index()
        {
              return _context.Shifts != null ? 
                          View(await _context.Shifts.ToListAsync()) :
                          Problem("Entity set 'MovieManagementMVCContext.Shifts'  is null.");
        }

        // GET: Shifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shifts == null)
            {
                return NotFound();
            }

            var shifts = await _context.Shifts
                .FirstOrDefaultAsync(m => m.ShitId == id);
            if (shifts == null)
            {
                return NotFound();
            }

            return View(shifts);
        }

        // GET: Shifts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShitId,ShitTime")] Shifts shifts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shifts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shifts);
        }

        // GET: Shifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shifts == null)
            {
                return NotFound();
            }

            var shifts = await _context.Shifts.FindAsync(id);
            if (shifts == null)
            {
                return NotFound();
            }
            return View(shifts);
        }

        // POST: Shifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShitId,ShitTime")] Shifts shifts)
        {
            if (id != shifts.ShitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shifts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftsExists(shifts.ShitId))
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
            return View(shifts);
        }

        // GET: Shifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shifts == null)
            {
                return NotFound();
            }

            var shifts = await _context.Shifts
                .FirstOrDefaultAsync(m => m.ShitId == id);
            if (shifts == null)
            {
                return NotFound();
            }

            return View(shifts);
        }

        // POST: Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shifts == null)
            {
                return Problem("Entity set 'MovieManagementMVCContext.Shifts'  is null.");
            }
            var shifts = await _context.Shifts.FindAsync(id);
            if (shifts != null)
            {
                _context.Shifts.Remove(shifts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftsExists(int id)
        {
          return (_context.Shifts?.Any(e => e.ShitId == id)).GetValueOrDefault();
        }
    }
}
