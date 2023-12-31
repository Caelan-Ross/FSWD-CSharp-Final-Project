﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MACK;
using MACK.Models;
using MACK.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace MACK.Controllers
{
    [Authorize]
    public class ModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Models
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Models.Include(m => m.Manufacturer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Models/Create
        public IActionResult Create()
        {
            var manufacturers = _context.Manufacturers.Select(m => new SelectListItem
            {
                Value = m.ManufacturerId.ToString(),
                Text = m.ManufacturerName
            }).ToList();

            ViewBag.Manufacturers = manufacturers;

            return View();
        }

        // POST: Models/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelId,ModelName,ManufacturerId")] Model model)
        {
            ModelState.Remove("Vehicles");//Remove virtuals
            ModelState.Remove("Manufacturer");//Remove virtuals

            if (ModelState.IsValid)
            {
                ModelHandlers.CreateModel(model.ModelName,  model.ManufacturerId);
                return RedirectToAction(nameof(Index));
            }

            var manufacturers = _context.Manufacturers.Select(m => new SelectListItem
            {
                Value = m.ManufacturerId.ToString(),
                Text = m.ManufacturerName
            }).ToList();

            ViewBag.Manufacturers = manufacturers;

            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Models == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .Include(m => m.Manufacturer)
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Models == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Models'  is null.");
            }
            Model model = ModelHandlers.GetModelById((int)id);
            if(model != null)
            {
                ModelHandlers.DeleteModel(model);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
          return (_context.Models?.Any(e => e.ModelId == id)).GetValueOrDefault();
        }
    }
}
