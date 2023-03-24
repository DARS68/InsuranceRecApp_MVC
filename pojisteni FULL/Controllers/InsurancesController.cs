using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pojisteni_FULL.Data;
using pojisteni_FULL.Extensions.Alerts;
using pojisteni_FULL.Models;
using pojisteni_FULL.Models.ViewModels;

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
				.FirstOrDefaultAsync(m => m.InsuranceID == id);

			if (insurance == null)
			{
				return NotFound();
			}

			return View(insurance);
		}

		// GET: Insurances/Create
		public IActionResult Create()
		{
			if (!TempData.ContainsKey("InsuredPersonID"))
			{
				return View();
			}

			int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

			// Keep TempData alive
			TempData.Keep();

			InsuredPerson insuredPerson = DB.InsuredPerson.Find(insuredPersonId);

			// Another type of class initializaion, the Constructor is called implicitly
			InsuredPersonInsuraceViewModel viewModel = new InsuredPersonInsuraceViewModel
			{
				InsuredPersonId = insuredPerson.InsuredPersonID,
				FirstName = insuredPerson.FirstName,
				LastName = insuredPerson.LastName
			};

			return View(viewModel);
		}

		// POST: Insurances/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(InsuredPersonInsuraceViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			InsuredPerson insuredPerson = DB.InsuredPerson.Find(viewModel.InsuredPersonId);

			Insurance insurance = new Insurance
			{
				// Insurance data
				InsuranceName = viewModel.InsuranceName,
				InsuranceDescription = viewModel.InsuranceDescription,
				InsuranceAmount = viewModel.InsuranceAmount,
				SubjectOfInsurance = viewModel.SubjectOfInsurance,
				ValidFrom = viewModel.ValidFrom,
				ValidTo = viewModel.ValidTo				
			};

			DB.Insurance.Add(insurance);

			insuredPerson.Insurances.Add(insurance);

			await DB.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		//// POST: Insurances/Create
		//// To protect from overposting attacks, enable the specific properties you want to bind to.
		//// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create([Bind("InsuredPersonID,InsuranceName,InsuranceDescription,InsuranceAmount,SubjectOfInsurance,ValidFrom,ValidTo,InsuredPersonID")] Insurance insurance)
		//{
		//	if (TempData.ContainsKey("InsuredPersonID"))
		//	{
		//		int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

		//		// Keep TempData alive
		//		TempData.Keep();

		//		var insuredPerson = await DB.InsuredPerson.FindAsync(insuredPersonId);
		//		ViewBag.InsuredPerson = insuredPerson;
		//	}

		//	if (ModelState.IsValid)
		//	{
		//		DB.Insurance.Add(insurance);
		//		// DB.Add(insurance);
		//		await DB.SaveChangesAsync();
		//		return RedirectToAction(nameof(Index)).WithSuccess("OK!", "Nová pojistná smlouva byla úspěšně založena!");
		//	}

		//	return View(insurance);
		//}

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
		public async Task<IActionResult> Edit(int id, [Bind("InsuredPersonID,InsuranceName,InsuranceDescription,InsuranceAmount,SubjectOfInsurance,ValidFrom,ValidTo")] Insurance insurance)
		{
			if (id != insurance.InsuranceID)
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
					if (!InsuranceExists(insurance.InsuranceID))
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
				.FirstOrDefaultAsync(m => m.InsuranceID == id);
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
			return DB.Insurance.Any(e => e.InsuranceID == id);
		}
	}
}
