using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pojisteni_FULL.Data;
using pojisteni_FULL.Models;

namespace pojisteni_FULL.Controllers
{
    public class InsuredPersonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsuredPersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InsuredPersons
        public async Task<IActionResult> Index()
        {
            return View(await _context.InsuredPerson.ToListAsync());
        }

        // GET: InsuredPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InsuredPerson == null)
            {
                return NotFound();
            }

            var insuredPerson = await _context.InsuredPerson.FirstOrDefaultAsync(m => m.Id == id);
            if (insuredPerson == null)
            {
                return NotFound();
            }

            return View(insuredPerson);
        }

        // GET: InsuredPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsuredPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,StreetAndNumber,City,ZipCode")] InsuredPerson insuredPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuredPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuredPerson);
        }

        // GET: InsuredPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InsuredPerson == null)
            {
                return NotFound();
            }

            var insuredPerson = await _context.InsuredPerson.FindAsync(id);
            if (insuredPerson == null)
            {
                return NotFound();
            }
            return View(insuredPerson);
        }

        // POST: InsuredPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,StreetAndNumber,City,ZipCode")] InsuredPerson insuredPerson)
        {
            if (id != insuredPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuredPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuredPersonExists(insuredPerson.Id))
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
            return View(insuredPerson);
        }

        // GET: InsuredPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InsuredPerson == null)
            {
                return NotFound();
            }

            var insuredPerson = await _context.InsuredPerson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuredPerson == null)
            {
                return NotFound();
            }

            return View(insuredPerson);
        }

        // POST: InsuredPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InsuredPerson == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InsuredPerson'  is null.");
            }
            var insuredPerson = await _context.InsuredPerson.FindAsync(id);
            if (insuredPerson != null)
            {
                _context.InsuredPerson.Remove(insuredPerson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuredPersonExists(int id)
        {
            return _context.InsuredPerson.Any(e => e.Id == id);
        }
    }
}
