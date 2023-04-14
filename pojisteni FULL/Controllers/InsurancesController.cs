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
using pojisteni_FULL.Models.ViewModels.Items;
using pojisteni_FULL.Utils;

namespace pojisteni_FULL.Controllers
{
	public class InsurancesController : Controller
	{
		private readonly ApplicationDbContext db;

		public InsurancesController(ApplicationDbContext context)
		{
			db = context;
		}

		// GET: InsuranceItems
		public async Task<IActionResult> Index()
		{
			InsuranceListViewModel viewModel = new InsuranceListViewModel
			{
				InsuranceItems = await db.Insurance.Select((Insurance i) => InsuranceItem.GetInsuranceItem(i)).ToListAsync()
			};

			return View(viewModel);
		}


		// GET: InsuranceItems/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			/*
			if (id == null || db.Insurance == null)
			{
				return NotFound();
			}

			Insurance insurance = await db.Insurance
				.Include(i => i.InsuredPersonItem)
				.FirstOrDefaultAsync(m => m.InsuranceID == id);
			
			int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

			// Keep TempData alive
			TempData.Keep();
			InsuredPersonItem insuredPerson = db.InsuredPersonItem.Find(insuredPersonId);
		

			if (insurance == null)
			{
				return NotFound();
			}

			// DEPRECATED -> use the bellow example
			//InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			//{
			//	InsuranceID = insurance.InsuranceID,
			//	InsuranceName = insurance.InsuranceName,
			//	InsuranceDescription = insurance.InsuranceDescription,
			//	InsuranceAmount = insurance.InsuranceAmount,
			//	SubjectOfInsurance = insurance.SubjectOfInsurance,
			//	ValidFrom = insurance.ValidFrom,
			//	ValidTo = insurance.ValidTo,
			//	InsuredPersonID = insurance.InsuredPersonId,
			//	//InsuredPersonID = insuredPerson.InsuredPersonID,
			//	FirstName = insuredPerson.FirstName,
			//	LastName = insuredPerson.LastName,
			//};
			*/

			Insurance insurance = await db.Insurance.FirstOrDefaultAsync(i => i.InsuranceID == id);

			if (insurance.IsNull()) // if (insurance == null) or if (insurance is null)
			{
				return NotFound();
			}

			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				InsuranceItem = InsuranceItem.GetInsuranceItem(insurance),
				InsuredPersonItem = InsuredPersonItem.GetInsuredPersonItem(insurance.InsuredPerson)
			};

			return View(viewModel);
		}


		// GET: InsuranceItems/Create
		public IActionResult Create(int? id)
		{
			// Access the database and get the insured person for whom we are creating the insurance
			InsuredPerson insuredPerson = db.InsuredPerson.FirstOrDefault(p => p.InsuredPersonID == id);

			// Check if the the insured person is in the database
			if (insuredPerson.IsNull()) // if (insurance == null) or if (insurance is null)
			{
				return View();
			}

			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				InsuranceItem = new InsuranceItem(),
				InsuredPersonItem = InsuredPersonItem.GetInsuredPersonItem(insuredPerson)
			};

			return View(viewModel);
		}

		// POST: InsuranceItems/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(InsuredPersonInsuranceViewModel viewModel)
		{
			//if (!ModelState.IsValid)
			//{
			//	return View(viewModel);
			//}

			Insurance insurance = new Insurance
			{
				// Insurance data
				InsuranceName = viewModel.InsuranceItem.InsuranceName,
				InsuranceDescription = viewModel.InsuranceItem.InsuranceDescription,
				InsuranceAmount = viewModel.InsuranceItem.InsuranceAmount,
				SubjectOfInsurance = viewModel.InsuranceItem.SubjectOfInsurance,
				ValidFrom = viewModel.InsuranceItem.ValidFrom,
				ValidTo = viewModel.InsuranceItem.ValidTo,
				InsuredPersonId = viewModel.InsuredPersonItem.InsuredPersonID
			};

			db.Insurance.Add(insurance);

			await db.SaveChangesAsync();

			return RedirectToAction(nameof(Index)).WithSuccess("Pojištění", "bylo úspěšně přidáno.");
		}


		// GET: InsuranceItems/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			Insurance insurance = await db.Insurance.FirstOrDefaultAsync(i => i.InsuranceID == id);

			if (insurance.IsNull()) 
			{
				return NotFound();
			}

			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				InsuranceItem = InsuranceItem.GetInsuranceItem(insurance),
				InsuredPersonItem = InsuredPersonItem.GetInsuredPersonItem(insurance.InsuredPerson)
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(InsuredPersonInsuranceViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			Insurance insurance = new Insurance
			{
				// Insurance data
				InsuranceID = viewModel.InsuranceItem.InsuranceID,
				InsuranceName = viewModel.InsuranceItem.InsuranceName,
				InsuranceDescription = viewModel.InsuranceItem.InsuranceDescription,
				InsuranceAmount = viewModel.InsuranceItem.InsuranceAmount,
				SubjectOfInsurance = viewModel.InsuranceItem.SubjectOfInsurance,
				ValidFrom = viewModel.InsuranceItem.ValidFrom,
				ValidTo = viewModel.InsuranceItem.ValidTo,
				InsuredPersonId = viewModel.InsuredPersonItem.InsuredPersonID
			};

			db.Insurance.Update(insurance);

			await db.SaveChangesAsync();

			return RedirectToAction(nameof(Index)).WithSuccess("Pojištění", "bylo úspěšně upraveno.");
		}

		// GET: InsuranceItems/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			Insurance insurance = await db.Insurance.FirstOrDefaultAsync(i => i.InsuranceID == id);

			if (insurance.IsNull()) // if (insurance == null) or if (insurance is null)
			{
				return NotFound();
			}

			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				InsuranceItem = InsuranceItem.GetInsuranceItem(insurance),
				InsuredPersonItem = InsuredPersonItem.GetInsuredPersonItem(insurance.InsuredPerson)
			};

			return View(viewModel);
		}


		// POST: InsuranceItems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(InsuredPersonInsuranceViewModel viewModel)
		{
			//if (!ModelState.IsValid)
			//{
			//	return View(viewModel);
			//}

			Insurance insurance = new Insurance
			{
				InsuranceID = viewModel.InsuranceItem.InsuranceID,
				InsuranceName = viewModel.InsuranceItem.InsuranceName,
				InsuranceDescription = viewModel.InsuranceItem.InsuranceDescription,
				InsuranceAmount = viewModel.InsuranceItem.InsuranceAmount,
				SubjectOfInsurance = viewModel.InsuranceItem.SubjectOfInsurance,
				ValidFrom = viewModel.InsuranceItem.ValidFrom,
				ValidTo = viewModel.InsuranceItem.ValidTo,
			};

			if (insurance != null)
			{
				db.Insurance.Remove(insurance);
			}

			await db.SaveChangesAsync();
			return RedirectToAction(nameof(Index)).WithSuccess("Pojištění", "bylo úspěšně odstraněno.");
		}


		private bool InsuranceExists(int id)
		{
			return db.Insurance.Any(e => e.InsuranceID == id);
		}
	}
}
