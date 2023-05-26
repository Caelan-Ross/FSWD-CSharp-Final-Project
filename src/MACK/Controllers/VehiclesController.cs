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
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vehicles.Include(v => v.Drivetrain).Include(v => v.ExteriorColour).Include(v => v.InteriorColour).Include(v => v.Series).Include(v => v.Transmission).Include(v => v.VehicleType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.Drivetrain)
                .Include(v => v.ExteriorColour)
                .Include(v => v.InteriorColour)
                .Include(v => v.Series)
                .Include(v => v.Transmission)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["DrivetrainId"] = new SelectList(_context.Drivetrains, "DrivetrainId", "DrivetrainType");
            ViewData["ExteriorColourId"] = new SelectList(_context.Colours, "ColourId", "ColourName");
            ViewData["InteriorColourId"] = new SelectList(_context.Colours, "ColourId", "ColourName");
            ViewData["SeriesId"] = new SelectList(_context.Series, "SeriesId", "SeriesName");
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionId", "TransmissionType");
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleTypes, "VehicleTypeId", "TypeName");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,VIN,Year,SeriesId,VehicleTypeId,EngineCylinderCount,EngineDisplacement,Engine,Fuel,TransmissionId,BodyDoorCount,DrivetrainId,ExteriorColourId,InteriorColourId,CityMPG,HighwayMPG,Weight,Length,Width,Height")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                VehicleHandlers.CreateVehicle(vehicle.VIN, vehicle.Year, vehicle.SeriesId,
                    vehicle.VehicleTypeId, vehicle.EngineCylinderCount, vehicle.EngineDisplacement, vehicle.Engine, vehicle.Fuel,
                    vehicle.TransmissionId, vehicle.BodyDoorCount, vehicle.DrivetrainId, vehicle.ExteriorColourId, vehicle.InteriorColourId,
                    vehicle.CityMPG, vehicle.HighwayMPG, vehicle.Weight, vehicle.Length, vehicle.Width, vehicle.Height);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrivetrainId"] = new SelectList(_context.Drivetrains, "DrivetrainId", "DrivetrainType", vehicle.DrivetrainId);
            ViewData["ExteriorColourId"] = new SelectList(_context.Colours, "ColourId", "ColourName", vehicle.ExteriorColourId);
            ViewData["InteriorColourId"] = new SelectList(_context.Colours, "ColourId", "ColourName", vehicle.InteriorColourId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "SeriesId", "SeriesName", vehicle.SeriesId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionId", "TransmissionType", vehicle.TransmissionId);
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleTypes, "VehicleTypeId", "TypeName", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["DrivetrainId"] = new SelectList(_context.Drivetrains, "DrivetrainId", "DrivetrainType", vehicle.DrivetrainId);
            ViewData["ExteriorColourId"] = new SelectList(_context.Colours, "ColourId", "ColourName", vehicle.ExteriorColourId);
            ViewData["InteriorColourId"] = new SelectList(_context.Colours, "ColourId", "ColourName", vehicle.InteriorColourId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "SeriesId", "SeriesName", vehicle.SeriesId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionId", "TransmissionType", vehicle.TransmissionId);
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleTypes, "VehicleTypeId", "TypeName", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,VIN,Year,SeriesId,VehicleTypeId,EngineCylinderCount,EngineDisplacement,Engine,Fuel,TransmissionId,BodyDoorCount,DrivetrainId,ExteriorColourId,InteriorColourId,CityMPG,HighwayMPG,Weight,Length,Width,Height")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    VehicleHandlers.UpdateVehicle(vehicle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleId))
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
            ViewData["DrivetrainId"] = new SelectList(_context.Drivetrains, "DrivetrainId", "DrivetrainType", vehicle.DrivetrainId);
            ViewData["ExteriorColourId"] = new SelectList(_context.Colours, "ColourId", "ColourName", vehicle.ExteriorColourId);
            ViewData["InteriorColourId"] = new SelectList(_context.Colours, "ColourId", "ColourName", vehicle.InteriorColourId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "SeriesId", "SeriesName", vehicle.SeriesId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionId", "TransmissionType", vehicle.TransmissionId);
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleTypes, "VehicleTypeId", "TypeName", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.Drivetrain)
                .Include(v => v.ExteriorColour)
                .Include(v => v.InteriorColour)
                .Include(v => v.Series)
                .Include(v => v.Transmission)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
            }
            Vehicle vehicle = VehicleHandlers.GetVehicleById(id);
            if (vehicle != null)
            {
                VehicleHandlers.DeleteVehicle(vehicle);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
          return (_context.Vehicles?.Any(e => e.VehicleId == id)).GetValueOrDefault();
        }
    }
}
