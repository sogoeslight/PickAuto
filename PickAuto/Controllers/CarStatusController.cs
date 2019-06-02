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
    public class CarStatusController : Controller
    {
        private readonly PickAutoContext _context;

        public CarStatusController(PickAutoContext context)
        {
            _context = context;
        }

        // GET: CarStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarStatus.ToListAsync());
        }

        // GET: CarStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carStatus = await _context.CarStatus
                .FirstOrDefaultAsync(m => m.CarStatusId == id);
            if (carStatus == null)
            {
                return NotFound();
            }

            return View(carStatus);
        }

        // GET: CarStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarStatusId,Name")] CarStatus carStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carStatus);
        }

        // GET: CarStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carStatus = await _context.CarStatus.FindAsync(id);
            if (carStatus == null)
            {
                return NotFound();
            }
            return View(carStatus);
        }

        // POST: CarStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarStatusId,Name")] CarStatus carStatus)
        {
            if (id != carStatus.CarStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarStatusExists(carStatus.CarStatusId))
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
            return View(carStatus);
        }

        // GET: CarStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carStatus = await _context.CarStatus
                .FirstOrDefaultAsync(m => m.CarStatusId == id);
            if (carStatus == null)
            {
                return NotFound();
            }

            return View(carStatus);
        }

        // POST: CarStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carStatus = await _context.CarStatus.FindAsync(id);
            _context.CarStatus.Remove(carStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarStatusExists(int id)
        {
            return _context.CarStatus.Any(e => e.CarStatusId == id);
        }
    }
}
