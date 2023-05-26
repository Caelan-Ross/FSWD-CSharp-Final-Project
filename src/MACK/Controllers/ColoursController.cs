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
    public class ColoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Colours
        public async Task<IActionResult> Index()
        {
              return _context.Colours != null ? 
                          View(await _context.Colours.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Colours'  is null.");
        }

        // GET: Colours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colours == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours
                .FirstOrDefaultAsync(m => m.ColourId == id);
            if (colour == null)
            {
                return NotFound();
            }

            return View(colour);
        }

        // GET: Colours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColourId,ColourName,VehicleId")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                ColourHandlers.CreateColour(colour.ColourName, colour.VehicleId);
                return RedirectToAction(nameof(Index));
            }
            return View(colour);
        }

        // GET: Colours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colours == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours.FindAsync(id);
            if (colour == null)
            {
                return NotFound();
            }
            return View(colour);
        }

        // POST: Colours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColourId,ColourName,VehicleId")] Colour colour)
        {
            if (id != colour.ColourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ColourHandlers.UpdateColour(colour);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColourExists(colour.ColourId))
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
            return View(colour);
        }

        // GET: Colours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colours == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours
                .FirstOrDefaultAsync(m => m.ColourId == id);
            if (colour == null)
            {
                return NotFound();
            }

            return View(colour);
        }

        // POST: Colours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colours == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Colours'  is null.");
            }
            Colour colour = ColourHandlers.GetColourById(id);
            if (colour != null)
            {
                ColourHandlers.DeleteColour(colour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColourExists(int id)
        {
          return (_context.Colours?.Any(e => e.ColourId == id)).GetValueOrDefault();
        }
    }
}
