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
            var pickAutoContext = _context.CarModel.Include(c => c.FuelType).Include(c => c.Gearbox).Include(c => c.Manufacturer).Include(c => c.WheelDrive);
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
                .Include(c => c.FuelType)
                .Include(c => c.Gearbox)
                .Include(c => c.Manufacturer)
                .Include(c => c.WheelDrive)
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
            ViewData["FuelTypeId"] = new SelectList(_context.FuelType, "FuelTypeId", "Name");
            ViewData["GearboxId"] = new SelectList(_context.GearBox, "GearboxId", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Name");
            ViewData["WheelDriveId"] = new SelectList(_context.WheelDrive, "WheelDriveId", "Name");
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarModelId,Name,ProductionYear,NumberOfSeats,GearboxId,FuelTypeId,WheelDriveId,ManufacturerId")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuelTypeId"] = new SelectList(_context.FuelType, "FuelTypeId", "Name", carModel.FuelTypeId);
            ViewData["GearboxId"] = new SelectList(_context.GearBox, "GearboxId", "Name", carModel.GearboxId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Name", carModel.ManufacturerId);
            ViewData["WheelDriveId"] = new SelectList(_context.WheelDrive, "WheelDriveId", "Name", carModel.WheelDriveId);
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
            ViewData["FuelTypeId"] = new SelectList(_context.FuelType, "FuelTypeId", "Name", carModel.FuelTypeId);
            ViewData["GearboxId"] = new SelectList(_context.GearBox, "GearboxId", "Name", carModel.GearboxId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Name", carModel.ManufacturerId);
            ViewData["WheelDriveId"] = new SelectList(_context.WheelDrive, "WheelDriveId", "Name", carModel.WheelDriveId);
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarModelId,Name,ProductionYear,NumberOfSeats,GearboxId,FuelTypeId,WheelDriveId,ManufacturerId")] CarModel carModel)
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
            ViewData["FuelTypeId"] = new SelectList(_context.FuelType, "FuelTypeId", "Name", carModel.FuelTypeId);
            ViewData["GearboxId"] = new SelectList(_context.GearBox, "GearboxId", "Name", carModel.GearboxId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Name", carModel.ManufacturerId);
            ViewData["WheelDriveId"] = new SelectList(_context.WheelDrive, "WheelDriveId", "Name", carModel.WheelDriveId);
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
                .Include(c => c.FuelType)
                .Include(c => c.Gearbox)
                .Include(c => c.Manufacturer)
                .Include(c => c.WheelDrive)
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
