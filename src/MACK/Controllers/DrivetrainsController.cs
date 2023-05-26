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
    public class DrivetrainsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrivetrainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Drivetrains
        public async Task<IActionResult> Index()
        {
              return _context.Drivetrains != null ? 
                          View(await _context.Drivetrains.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Drivetrains'  is null.");
        }

        // GET: Drivetrains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drivetrains == null)
            {
                return NotFound();
            }

            var drivetrain = await _context.Drivetrains
                .FirstOrDefaultAsync(m => m.DrivetrainId == id);
            if (drivetrain == null)
            {
                return NotFound();
            }

            return View(drivetrain);
        }

        // GET: Drivetrains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drivetrains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrivetrainId,DrivetrainType,VehicleId")] Drivetrain drivetrain)
        {
            if (ModelState.IsValid)
            {
                DrivetrainHandlers.CreateDrivetrain(drivetrain.DrivetrainType, drivetrain.VehicleId);
                return RedirectToAction(nameof(Index));
            }
            return View(drivetrain);
        }

        // GET: Drivetrains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drivetrains == null)
            {
                return NotFound();
            }

            var drivetrain = await _context.Drivetrains.FindAsync(id);
            if (drivetrain == null)
            {
                return NotFound();
            }
            return View(drivetrain);
        }

        // POST: Drivetrains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrivetrainId,DrivetrainType,VehicleId")] Drivetrain drivetrain)
        {
            if (id != drivetrain.DrivetrainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DrivetrainHandlers.UpdateDrivetrain(drivetrain);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrivetrainExists(drivetrain.DrivetrainId))
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
            return View(drivetrain);
        }

        // GET: Drivetrains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drivetrains == null)
            {
                return NotFound();
            }

            var drivetrain = await _context.Drivetrains
                .FirstOrDefaultAsync(m => m.DrivetrainId == id);
            if (drivetrain == null)
            {
                return NotFound();
            }

            return View(drivetrain);
        }

        // POST: Drivetrains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drivetrains == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Drivetrains'  is null.");
            }
            Drivetrain drivetrain = DrivetrainHandlers.GetDrivetrainById(id);
            if (drivetrain != null)
            {
                DrivetrainHandlers.DeleteDrivetrain(drivetrain);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrivetrainExists(int id)
        {
          return (_context.Drivetrains?.Any(e => e.DrivetrainId == id)).GetValueOrDefault();
        }
    }
}
