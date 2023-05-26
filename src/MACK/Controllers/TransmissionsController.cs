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
    public class TransmissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransmissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transmissions
        public async Task<IActionResult> Index()
        {
              return _context.Transmissions != null ? 
                          View(await _context.Transmissions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Transmissions'  is null.");
        }

        // GET: Transmissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transmissions == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmissions
                .FirstOrDefaultAsync(m => m.TransmissionId == id);
            if (transmission == null)
            {
                return NotFound();
            }

            return View(transmission);
        }

        // GET: Transmissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transmissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransmissionId,TransmissionType,TransmissionGears")] Transmission transmission)
        {
            if (ModelState.IsValid)
            {
                TransmissionHandlers.CreateTransmission(transmission.TransmissionType, transmission.TransmissionGears);
                return RedirectToAction(nameof(Index));
            }
            return View(transmission);
        }

        // GET: Transmissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transmissions == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmissions.FindAsync(id);
            if (transmission == null)
            {
                return NotFound();
            }
            return View(transmission);
        }

        // POST: Transmissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransmissionId,TransmissionType,TransmissionGears")] Transmission transmission)
        {
            if (id != transmission.TransmissionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TransmissionHandlers.UpdateTransmission(transmission);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransmissionExists(transmission.TransmissionId))
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
            return View(transmission);
        }

        // GET: Transmissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transmissions == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmissions
                .FirstOrDefaultAsync(m => m.TransmissionId == id);
            if (transmission == null)
            {
                return NotFound();
            }

            return View(transmission);
        }

        // POST: Transmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transmissions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transmissions'  is null.");
            }
            Transmission transmission = TransmissionHandlers.GetTransmissionById(id);
            if (transmission != null)
            {
                TransmissionHandlers.DeleteTransmission(transmission);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransmissionExists(int id)
        {
          return (_context.Transmissions?.Any(e => e.TransmissionId == id)).GetValueOrDefault();
        }
    }
}
