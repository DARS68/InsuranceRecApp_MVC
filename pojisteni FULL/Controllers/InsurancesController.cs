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
	public class InsurancesController : Controller
	{
		private readonly ApplicationDbContext DB;

		public InsurancesController(ApplicationDbContext context)
		{
			DB = context;
		}

		// GET: Insurances
		public async Task<IActionResult> Index()
		{
			return View(await DB.Insurance.ToListAsync());
		}

		// GET: Insurances/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || DB.Insurance == null)
			{
				return NotFound();
			}

			var insurance = await DB.Insurance
				.Include(i => i.InsuredPerson)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (insurance == null)
			{
				return NotFound();
			}

			return View(insurance);
		}

		// GET: Insurances/Create
		public IActionResult Create()
		{
			if (TempData.ContainsKey("InsuredPersonId"))
			{
				int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonId"].ToString());

				// Keep TempData alive
				TempData.Keep();

				var insuredPerson = DB.InsuredPerson.Find(insuredPersonId);
				ViewBag.InsuredPerson = insuredPerson;
			}
			return View();
		}

		// POST: Insurances/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,InsuranceName,InsuranceDescription,InsuranceAmount,SubjectOfInsurance,ValidFrom,ValidTo,InsuredPersonId")] Insurance insurance)
		{
			if (ModelState.IsValid)
			{
				DB.Insurance.Add(insurance);
				// DB.Add(insurance);
				await DB.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			if (TempData.ContainsKey("InsuredPersonId"))
			{
				int InsuredPersonId = Convert.ToInt32(TempData["InsuredPersonId"].ToString());

				// Keep TempData alive
				TempData.Keep();

				var InsuredPerson = await DB.InsuredPerson.FindAsync(InsuredPersonId);
				ViewBag.InsuredPerson = InsuredPerson;
			}

			return View(insurance);
		}

		// GET: Insurances/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || DB.Insurance == null)
			{
				return NotFound();
			}

			var insurance = await DB.Insurance.FindAsync(id);
			if (insurance == null)
			{
				return NotFound();
			}
			return View(insurance);
		}

		// POST: Insurances/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,InsuranceName,InsuranceDescription,InsuranceAmount,SubjectOfInsurance,ValidFrom,ValidTo")] Insurance insurance)
		{
			if (id != insurance.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					DB.Update(insurance);
					await DB.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!InsuranceExists(insurance.Id))
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
			return View(insurance);
		}

		// GET: Insurances/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || DB.Insurance == null)
			{
				return NotFound();
			}

			var insurance = await DB.Insurance
				.FirstOrDefaultAsync(m => m.Id == id);
			if (insurance == null)
			{
				return NotFound();
			}

			return View(insurance);
		}

		// POST: Insurances/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (DB.Insurance == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Insurance'  is null.");
			}
			var insurance = await DB.Insurance.FindAsync(id);
			if (insurance != null)
			{
				DB.Insurance.Remove(insurance);
			}

			await DB.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool InsuranceExists(int id)
		{
			return DB.Insurance.Any(e => e.Id == id);
		}
	}
}
