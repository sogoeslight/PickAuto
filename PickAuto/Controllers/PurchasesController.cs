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
    public class PurchasesController : Controller
    {
        private readonly PickAutoContext _context;

        public PurchasesController(PickAutoContext context)
        {
            _context = context;
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            var pickAutoContext = _context.Purchase.Include(p => p.Car).Include(p => p.Customer).Include(p => p.Worker);
            return View(await pickAutoContext.ToListAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .Include(p => p.Car)
                .Include(p => p.Customer)
                .Include(p => p.Worker)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            ViewData["CarForeignKey"] = new SelectList(_context.Car, "CarId", "CarId");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Email");
            ViewData["WorkerId"] = new SelectList(_context.Worker, "WorkerId", "Email");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseId,PaymentDate,CarForeignKey,WorkerId,CustomerId")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarForeignKey"] = new SelectList(_context.Car, "CarId", "CarId", purchase.CarForeignKey);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Email", purchase.CustomerId);
            ViewData["WorkerId"] = new SelectList(_context.Worker, "WorkerId", "Email", purchase.WorkerId);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            ViewData["CarForeignKey"] = new SelectList(_context.Car, "CarId", "CarId", purchase.CarForeignKey);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Email", purchase.CustomerId);
            ViewData["WorkerId"] = new SelectList(_context.Worker, "WorkerId", "Email", purchase.WorkerId);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseId,PaymentDate,CarForeignKey,WorkerId,CustomerId")] Purchase purchase)
        {
            if (id != purchase.PurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.PurchaseId))
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
            ViewData["CarForeignKey"] = new SelectList(_context.Car, "CarId", "CarId", purchase.CarForeignKey);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Email", purchase.CustomerId);
            ViewData["WorkerId"] = new SelectList(_context.Worker, "WorkerId", "Email", purchase.WorkerId);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .Include(p => p.Car)
                .Include(p => p.Customer)
                .Include(p => p.Worker)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.PurchaseId == id);
        }
    }
}
