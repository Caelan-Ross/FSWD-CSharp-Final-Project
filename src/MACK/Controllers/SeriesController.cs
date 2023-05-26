using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MACK;
using MACK.Models;
using MACK.Handlers;

namespace MACK.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Series
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Series.Include(s => s.Model);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Series/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }

            var series = await _context.Series
                .Include(s => s.Model)
                .FirstOrDefaultAsync(m => m.SeriesId == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // GET: Series/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.Models, "ModelId", "ModelName");
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeriesId,SeriesName,ModelId")] Series series)
        {
            if (ModelState.IsValid)
            {
                SeriesHandlers.CreateSeries(series.SeriesName, series.ModelId);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.Models, "ModelId", "ModelName", series.ModelId);
            return View(series);
        }

        // GET: Series/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }

            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }
            ViewData["ModelId"] = new SelectList(_context.Models, "ModelId", "ModelName", series.ModelId);
            return View(series);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeriesId,SeriesName,ModelId")] Series series)
        {
            if (id != series.SeriesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SeriesHandlers.UpdateSeries(series);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesExists(series.SeriesId))
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
            ViewData["ModelId"] = new SelectList(_context.Models, "ModelId", "ModelName", series.ModelId);
            return View(series);
        }

        // GET: Series/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }

            var series = await _context.Series
                .Include(s => s.Model)
                .FirstOrDefaultAsync(m => m.SeriesId == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Series == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Series'  is null.");
            }
            Series series = SeriesHandlers.GetSeriesById(id);
            if (series != null)
            {
                SeriesHandlers.DeleteSeries(series);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeriesExists(int id)
        {
          return (_context.Series?.Any(e => e.SeriesId == id)).GetValueOrDefault();
        }
    }
}
