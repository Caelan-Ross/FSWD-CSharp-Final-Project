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
    public class VehicleListingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleListingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehicleListings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VehicleListings.Include(v => v.Condition).Include(v => v.Dealership).Include(v => v.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VehicleListings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VehicleListings == null)
            {
                return NotFound();
            }

            var vehicleListing = await _context.VehicleListings
                .Include(v => v.Condition)
                .Include(v => v.Dealership)
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.ListingId == id);
            if (vehicleListing == null)
            {
                return NotFound();
            }

            return View(vehicleListing);
        }

        // GET: VehicleListings/Create
        public IActionResult Create()
        {
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionName");
            ViewData["DealershipId"] = new SelectList(_context.Dealerships, "DealershipId", "DealershipName");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "Engine");
            return View();
        }

        // POST: VehicleListings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListingId,VIN,StockNumber,Odometer,MSRP,Price,InventoryDate,Certified,Description,Features,PhotoUrlList,PhotosLastModifiedDate,Age,Cost,CreatedAt,UpdatedAt,DeletedAt,VehicleId,DealershipId,ConditionId")] VehicleListing vehicleListing)
        {
            if (ModelState.IsValid)
            {
                VehicleListingHandlers.CreateVehicleListing(vehicleListing.VIN, vehicleListing.StockNumber, vehicleListing.Odometer,
                    vehicleListing.MSRP, vehicleListing.Price, vehicleListing.InventoryDate, vehicleListing.Certified, vehicleListing.Description,
                    vehicleListing.Features, vehicleListing.PhotoUrlList, DateTime.Now, vehicleListing.Age, vehicleListing.Cost, DateTime.Now,
                    DateTime.Now, vehicleListing.DeletedAt, vehicleListing.VehicleId, vehicleListing.DealershipId, vehicleListing.ConditionId);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionName", vehicleListing.ConditionId);
            ViewData["DealershipId"] = new SelectList(_context.Dealerships, "DealershipId", "DealershipName", vehicleListing.DealershipId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "Engine", vehicleListing.VehicleId);
            return View(vehicleListing);
        }

        // GET: VehicleListings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VehicleListings == null)
            {
                return NotFound();
            }

            var vehicleListing = await _context.VehicleListings.FindAsync(id);
            if (vehicleListing == null)
            {
                return NotFound();
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionName", vehicleListing.ConditionId);
            ViewData["DealershipId"] = new SelectList(_context.Dealerships, "DealershipId", "DealershipName", vehicleListing.DealershipId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "Engine", vehicleListing.VehicleId);
            return View(vehicleListing);
        }

        // POST: VehicleListings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListingId,VIN,StockNumber,Odometer,MSRP,Price,InventoryDate,Certified,Description,Features,PhotoUrlList,PhotosLastModifiedDate,Age,Cost,CreatedAt,UpdatedAt,DeletedAt,VehicleId,DealershipId,ConditionId")] VehicleListing vehicleListing)
        {
            if (id != vehicleListing.ListingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    VehicleListingHandlers.UpdateVehicleListing(vehicleListing);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleListingExists(vehicleListing.ListingId))
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
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionName", vehicleListing.ConditionId);
            ViewData["DealershipId"] = new SelectList(_context.Dealerships, "DealershipId", "DealershipName", vehicleListing.DealershipId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "Engine", vehicleListing.VehicleId);
            return View(vehicleListing);
        }

        // GET: VehicleListings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VehicleListings == null)
            {
                return NotFound();
            }

            var vehicleListing = await _context.VehicleListings
                .Include(v => v.Condition)
                .Include(v => v.Dealership)
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.ListingId == id);
            if (vehicleListing == null)
            {
                return NotFound();
            }

            return View(vehicleListing);
        }

        // POST: VehicleListings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VehicleListings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VehicleListings'  is null.");
            }
            VehicleListing vehicleListing = VehicleListingHandlers.GetVehicleListingById(id);
            if (vehicleListing != null)
            {
                VehicleListingHandlers.DeleteVehicleListing(vehicleListing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleListingExists(int id)
        {
          return (_context.VehicleListings?.Any(e => e.ListingId == id)).GetValueOrDefault();
        }
    }
}
