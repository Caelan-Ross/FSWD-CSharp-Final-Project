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
    public class DealershipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DealershipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dealerships
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dealerships.Include(d => d.Corporation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dealerships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dealerships == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealerships
                .Include(d => d.Corporation)
                .FirstOrDefaultAsync(m => m.DealershipId == id);
            if (dealership == null)
            {
                return NotFound();
            }

            return View(dealership);
        }

        // GET: Dealerships/Create
        public IActionResult Create()
        {
            ViewData["CorporationId"] = new SelectList(_context.Corporations, "CorporationId", "CorporationName");
            return View();
        }

        // POST: Dealerships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DealershipId,DealershipName,CorporationId,AddressId")] Dealership dealership)
        {
            if (ModelState.IsValid)
            {
                DealershipHandlers.CreateDealership(dealership.DealershipName, dealership.CorporationId, dealership.AddressId);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CorporationId"] = new SelectList(_context.Corporations, "CorporationId", "CorporationName", dealership.CorporationId);
            return View(dealership);
        }

        // GET: Dealerships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dealerships == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealerships.FindAsync(id);
            if (dealership == null)
            {
                return NotFound();
            }
            ViewData["CorporationId"] = new SelectList(_context.Corporations, "CorporationId", "CorporationName", dealership.CorporationId);
            return View(dealership);
        }

        // POST: Dealerships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DealershipId,DealershipName,CorporationId,AddressId")] Dealership dealership)
        {
            if (id != dealership.DealershipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DealershipHandlers.UpdateDealership(dealership);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealershipExists(dealership.DealershipId))
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
            ViewData["CorporationId"] = new SelectList(_context.Corporations, "CorporationId", "CorporationName", dealership.CorporationId);
            return View(dealership);
        }

        // GET: Dealerships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dealerships == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealerships
                .Include(d => d.Corporation)
                .FirstOrDefaultAsync(m => m.DealershipId == id);
            if (dealership == null)
            {
                return NotFound();
            }

            return View(dealership);
        }

        // POST: Dealerships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dealerships == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Dealerships'  is null.");
            }
            Dealership dealership = DealershipHandlers.GetDealershipById(id);
            if (dealership != null)
            {
                DealershipHandlers.DeleteDealership(dealership);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealershipExists(int id)
        {
          return (_context.Dealerships?.Any(e => e.DealershipId == id)).GetValueOrDefault();
        }
    }
}
