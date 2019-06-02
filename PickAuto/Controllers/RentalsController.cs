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
    public class RentalsController : Controller
    {
        private readonly PickAutoContext _context;

        public RentalsController(PickAutoContext context)
        {
            _context = context;
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            var pickAutoContext = _context.Rental.Include(r => r.Car).Include(r => r.Customer).Include(r => r.Worker);
            return View(await pickAutoContext.ToListAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .Include(r => r.Worker)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            ViewData["CarForeignKey"] = new SelectList(_context.Car, "CarId", "CarId");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Email");
            ViewData["WorkerId"] = new SelectList(_context.Worker, "WorkerId", "Email");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalId,RentalStart,RentalEnd,PaymentDate,CarForeignKey,WorkerId,CustomerId")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarForeignKey"] = new SelectList(_context.Car, "CarId", "CarId", rental.CarForeignKey);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Email", rental.CustomerId);
            ViewData["WorkerId"] = new SelectList(_context.Worker, "WorkerId", "Email", rental.WorkerId);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["CarForeignKey"] = new SelectList(_context.Car, "CarId", "CarId", rental.CarForeignKey);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Email", rental.CustomerId);
            ViewData["WorkerId"] = new SelectList(_context.Worker, "WorkerId", "Email", rental.WorkerId);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalId,RentalStart,RentalEnd,PaymentDate,CarForeignKey,WorkerId,CustomerId")] Rental rental)
        {
            if (id != rental.RentalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.RentalId))
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
            ViewData["CarForeignKey"] = new SelectList(_context.Car, "CarId", "CarId", rental.CarForeignKey);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Email", rental.CustomerId);
            ViewData["WorkerId"] = new SelectList(_context.Worker, "WorkerId", "Email", rental.WorkerId);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .Include(r => r.Worker)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rental = await _context.Rental.FindAsync(id);
            _context.Rental.Remove(rental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
            return _context.Rental.Any(e => e.RentalId == id);
        }
    }
}
