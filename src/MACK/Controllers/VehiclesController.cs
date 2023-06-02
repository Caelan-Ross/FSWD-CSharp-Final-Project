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
using Microsoft.Extensions.Hosting.Internal;
using System.Web;
using Azure;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace MACK.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public VehiclesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context; 
            _hostEnvironment = hostEnvironment;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vehicles.Include(v => v.Model);
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
                .Include(v => v.Model)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        public IActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            if(file != null)
            {
                try
                {
                    string contentRootPath = _hostEnvironment.ContentRootPath;
                    string path = contentRootPath + $"\\Temp\\{file.FileName}";
                    using(FileStream stream = System.IO.File.Create(path))
                    {
                        await file.CopyToAsync(stream);
                    }

                    CSVHandler.ConvertDatatableToDb(CSVHandler.GetDataTableFromCsv(path));
                    System.IO.File.Delete(path);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.Models, "ModelId", "ModelName");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,VIN,Year,Fuel,ExteriorColour,InteriorColour,BodyDoorCount,Features,Description,IsUsed,IsAutomatic,ModelId,Price,StockNumber")] Vehicle vehicle)
        {
            ModelState.Remove("Model");//Remove virtuals

            if(VehicleHandlers.IfVehicleExists(vehicle.VIN,vehicle.ModelId))
            {
                ModelState.AddModelError(vehicle.VIN, "Vehicle with that VIN already exists.");
            }

            IFormCollection form = await Request.ReadFormAsync();
            IFormFile? csv = form.Files.FirstOrDefault();
            if(csv != null)
            {
                string contentRootPath = _hostEnvironment.ContentRootPath;
                string path = Path.Combine(contentRootPath, $"/Temp/{Path.GetFileName(csv.FileName)}");
                using(FileStream stream = System.IO.File.Create(path))
                {
                    await csv.CopyToAsync(stream);
                }


                return RedirectToAction(nameof(Index));
            }

            if(ModelState.IsValid)
            {
                
                

                VehicleHandlers.CreateVehicle(vehicle.VIN, vehicle.Year, vehicle.Fuel, vehicle.ExteriorColour,
                    vehicle.InteriorColour, vehicle.BodyDoorCount, vehicle.IsUsed, vehicle.IsAutomatic,
                    vehicle.Features, vehicle.Description, vehicle.ModelId, vehicle.Price, vehicle.StockNumber);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.Models, "ModelId", "ModelName", vehicle.ModelId);
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
            ViewData["ModelId"] = new SelectList(_context.Models, "ModelId", "ModelName", vehicle.ModelId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,VIN,Year,Fuel,ExteriorColour,InteriorColour,BodyDoorCount,Features,Description,IsUsed,IsAutomatic,ModelId,Price,StockNumber")] Vehicle vehicle)
        {
            vehicle.VehicleId = id;
            ModelState.Remove("Model");//Remove virtuals

            if(ModelState.IsValid)
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
            ViewData["ModelId"] = new SelectList(_context.Models, "ModelId", "ModelName", vehicle.ModelId);
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
                .Include(v => v.Model)
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
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
          return (_context.Vehicles?.Any(e => e.VehicleId == id)).GetValueOrDefault();
        }
    }
}
