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
    public class GearboxesController : Controller
    {
        private readonly PickAutoContext _context;

        public GearboxesController(PickAutoContext context)
        {
            _context = context;
        }

        // GET: Gearboxes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GearBox.ToListAsync());
        }

        // GET: Gearboxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gearbox = await _context.GearBox
                .FirstOrDefaultAsync(m => m.GearboxId == id);
            if (gearbox == null)
            {
                return NotFound();
            }

            return View(gearbox);
        }

        // GET: Gearboxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gearboxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GearboxId,Name")] Gearbox gearbox)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gearbox);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gearbox);
        }

        // GET: Gearboxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gearbox = await _context.GearBox.FindAsync(id);
            if (gearbox == null)
            {
                return NotFound();
            }
            return View(gearbox);
        }

        // POST: Gearboxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GearboxId,Name")] Gearbox gearbox)
        {
            if (id != gearbox.GearboxId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gearbox);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GearboxExists(gearbox.GearboxId))
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
            return View(gearbox);
        }

        // GET: Gearboxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gearbox = await _context.GearBox
                .FirstOrDefaultAsync(m => m.GearboxId == id);
            if (gearbox == null)
            {
                return NotFound();
            }

            return View(gearbox);
        }

        // POST: Gearboxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gearbox = await _context.GearBox.FindAsync(id);
            _context.GearBox.Remove(gearbox);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GearboxExists(int id)
        {
            return _context.GearBox.Any(e => e.GearboxId == id);
        }
    }
}
