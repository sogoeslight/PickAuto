using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PickAuto.Models;

namespace PickAuto.Controllers
{
    public class CarModelsController : Controller
    {
        private readonly PickAutoContext _context;

        public CarModelsController(PickAutoContext context)
        {
            _context = context;
        }

        // GET: CarModels
        public async Task<IActionResult> Index()
        {
            var pickAutoContext = _context.CarModel.Include(c => c.Gearbox).Include(c => c.Manufacturer);
            return View(await pickAutoContext.ToListAsync());
        }

        // GET: CarModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel
                .Include(c => c.Gearbox)
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(m => m.CarModelId == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // GET: CarModels/Create
        public IActionResult Create()
        {
            ViewData["GearboxId"] = new SelectList(_context.GearBox, "GearboxId", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Country");
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarModelId,ManufacturerId,Name,ProductionYear,NumberOfSeats,FuelType,GearboxId,EngineLiters,WheelDrive")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GearboxId"] = new SelectList(_context.GearBox, "GearboxId", "Name", carModel.GearboxId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Country", carModel.ManufacturerId);
            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }
            ViewData["GearboxId"] = new SelectList(_context.GearBox, "GearboxId", "Name", carModel.GearboxId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Country", carModel.ManufacturerId);
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarModelId,ManufacturerId,Name,ProductionYear,NumberOfSeats,FuelType,GearboxId,EngineLiters,WheelDrive")] CarModel carModel)
        {
            if (id != carModel.CarModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarModelExists(carModel.CarModelId))
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
            ViewData["GearboxId"] = new SelectList(_context.GearBox, "GearboxId", "Name", carModel.GearboxId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Country", carModel.ManufacturerId);
            return View(carModel);
        }

        // GET: CarModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel
                .Include(c => c.Gearbox)
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(m => m.CarModelId == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carModel = await _context.CarModel.FindAsync(id);
            _context.CarModel.Remove(carModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarModelExists(int id)
        {
            return _context.CarModel.Any(e => e.CarModelId == id);
        }
    }
}
