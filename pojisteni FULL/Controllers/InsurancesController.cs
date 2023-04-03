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
		private readonly ApplicationDbContext DB;

		public InsurancesController(ApplicationDbContext context)
		{
			DB = context;
		}

		// GET: InsuranceItems
		public async Task<IActionResult> Index()
		{

			/*
			//List<InsuranceListViewModel> viewModel = new List<InsuranceListViewModel>();
			//viewModel = await DB.Insurance.ToListAsync();

			//return View(viewModel);
			return View(await DB.Insurance.ToListAsync());
			*/

			// ===== Option 1 ========
			/*
			 			// Zobrazíme seznam všech pojištění
			List<InsuranceItem> insurances = new List<InsuranceItem>();

			foreach (Insurance dbInsurance in DB.Insurance)
			{
				insurances.Add(InsuranceItem.GetInsuranceItem(dbInsurance));
			}

			InsuranceListViewModel viewModel = new InsuranceListViewModel
			{
				Insuraces = insurances
			};

			return View(viewModel);
			 */

			// === Option 2 ===
			/*
			List<InsuranceItem> insurances = DB.Insurance.Select((Insurance i) => InsuranceItem.GetInsuranceItem(i)).ToList();

			InsuranceListViewModel viewModel = new InsuranceListViewModel
			{
				Insuraces = insurances
			};

			return View(viewModel);
			 */

			// === Option 3 ====
			InsuranceListViewModel viewModel = new InsuranceListViewModel
			{
				Insuraces = DB.Insurance.Select((Insurance i) => InsuranceItem.GetInsuranceItem(i)).ToList()
			};

			return View(viewModel);
		}


		// GET: InsuranceItems/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			/*
			if (id == null || DB.Insurance == null)
			{
				return NotFound();
			}

			Insurance insurance = await DB.Insurance
				.Include(i => i.InsuredPersonItem)
				.FirstOrDefaultAsync(m => m.InsuranceID == id);
			
			int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

			// Keep TempData alive
			TempData.Keep();
			InsuredPersonItem insuredPerson = DB.InsuredPersonItem.Find(insuredPersonId);
		

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

			Insurance insurance = DB.Insurance.FirstOrDefault(i => i.InsuranceID == id);

			if (insurance.IsNull()) // if (insurance == null) or if (insurance is null)
			{
				return NotFound();
			}

			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				InsuraceItem = InsuranceItem.GetInsuranceItem(insurance),
				InsuredPersonItem = InsuredPersonItem.GetInsuredPersonItem(insurance.InsuredPerson)
			};

			return View(viewModel);
		}


		// GET: InsuranceItems/Create
		public IActionResult Create()
		{
			/*
			if (!TempData.ContainsKey("InsuredPersonID"))
			{
				return View();
			}

			int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

			// Keep TempData alive
			TempData.Keep();

			InsuredPersonItem insuredPerson = DB.InsuredPersonItem.Find(insuredPersonId);

			// Another type of class initializaion, the Constructor is called implicitly
			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				InsuredPersonID = insuredPerson.InsuredPersonID,
				FirstName = insuredPerson.FirstName,
				LastName = insuredPerson.LastName
			};
			*/

			// Suggestion -> see method detail but instead of InsuranceId get the InsuredPersonId
			if (!TempData.ContainsKey("InsuredPersonID"))
			{
				return View();
				// Considet this: return NotFound();
			}

			int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

			// Keep TempData alive
			TempData.Keep();

			// Access the database and get the insured person for whom we are creating the insurance
			InsuredPerson insuredPerson = DB.InsuredPerson.FirstOrDefault(p => p.InsuredPersonID == insuredPersonId);

			// Check if the the insured person is in the database
			if (insuredPerson.IsNull()) // if (insurance == null) or if (insurance is null)
			{
				return View();
				// Considet this: return NotFound();
			}

			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				InsuraceItem = new InsuranceItem(),
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
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			InsuredPerson insuredPerson = DB.InsuredPerson.Find(viewModel.InsuredPersonItem.InsuredPersonID);

			Insurance insurance = new Insurance
			{
				// Insurance data
				InsuranceName = viewModel.InsuraceItem.InsuranceName,
				InsuranceDescription = viewModel.InsuraceItem.InsuranceDescription,
				InsuranceAmount = viewModel.InsuraceItem.InsuranceAmount,
				SubjectOfInsurance = viewModel.InsuraceItem.SubjectOfInsurance,
				ValidFrom = viewModel.InsuraceItem.ValidFrom,
				ValidTo = viewModel.InsuraceItem.ValidTo
			};

			DB.Insurance.Add(insurance);

			insuredPerson.Insurances.Add(insurance);

			await DB.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}


		// GET: InsuranceItems/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			/*
			if (id == null || DB.Insurance == null)
			{
				return NotFound();
			}

			var insurance = await DB.Insurance.FindAsync(id);
			if (insurance == null)
			{
				return NotFound();
			}
			int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

			// Keep TempData alive
			TempData.Keep();
			InsuredPersonItem insuredPerson = DB.InsuredPersonItem.Find(insuredPersonId);

			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				InsuranceID = insurance.InsuranceID,
				InsuranceName = insurance.InsuranceName,
				InsuranceDescription = insurance.InsuranceDescription,
				InsuranceAmount = insurance.InsuranceAmount,
				SubjectOfInsurance = insurance.SubjectOfInsurance,
				ValidFrom = insurance.ValidFrom,
				ValidTo = insurance.ValidTo,
				FirstName = insuredPerson.FirstName,
				LastName = insuredPerson.LastName,
				InsuredPersonID = insurance.InsuredPersonId
			};

			return View(viewModel);
			*/

			Insurance insurance = DB.Insurance.FirstOrDefault(i => i.InsuranceID == id);

			if (insurance.IsNull()) // if (insurance == null) or if (insurance is null)
			{
				return NotFound();
			}

			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				InsuraceItem = InsuranceItem.GetInsuranceItem(insurance),
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

			InsuredPerson insuredPerson = DB.InsuredPerson.Find(viewModel.InsuredPersonItem.InsuredPersonID);

			Insurance insurance = new Insurance
			{
				// Insurance data
				InsuranceID = viewModel.InsuranceID,
				InsuranceName = viewModel.InsuranceName,
				InsuranceDescription = viewModel.InsuranceDescription,
				InsuranceAmount = viewModel.InsuranceAmount,
				SubjectOfInsurance = viewModel.SubjectOfInsurance,
				ValidFrom = viewModel.ValidFrom,
				ValidTo = viewModel.ValidTo,
				InsuredPersonId = viewModel.InsuredPersonID
			};

			DB.Insurance.Update(insurance);

			await DB.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		// GET: InsuranceItems/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			//OK
			if (id == null || DB.Insurance == null)
			{
				return NotFound();
			}

			//asi OK (include??)
			var insurance = await DB.Insurance
				.Include(i => i.InsuredPerson)
				.FirstOrDefaultAsync(m => m.InsuranceID == id);

			if (insurance == null)
			{
				return NotFound();
			}

			int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

			// Keep TempData alive
			TempData.Keep();
			InsuredPerson insuredPerson = DB.InsuredPerson.Find(insuredPersonId);

			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				InsuranceID = insurance.InsuranceID,
				InsuranceName = insurance.InsuranceName,
				InsuranceDescription = insurance.InsuranceDescription,
				InsuranceAmount = insurance.InsuranceAmount,
				SubjectOfInsurance = insurance.SubjectOfInsurance,
				ValidFrom = insurance.ValidFrom,
				ValidTo = insurance.ValidTo,
				InsuredPersonID = insurance.InsuredPersonId,
				FirstName = insuredPerson.FirstName,
				LastName = insuredPerson.LastName,
			};

			return View(viewModel);
		}


		// POST: InsuranceItems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(InsuredPersonInsuranceViewModel viewModel)
		{
			if (DB.Insurance == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Insurance'  is null.");
			}

			Insurance insurance = new Insurance
			{
				InsuranceID = viewModel.InsuranceID,
				InsuranceName = viewModel.InsuranceName,
				InsuranceDescription = viewModel.InsuranceDescription,
				InsuranceAmount = viewModel.InsuranceAmount,
				SubjectOfInsurance = viewModel.SubjectOfInsurance,
				ValidFrom = viewModel.ValidFrom,
				ValidTo = viewModel.ValidTo,
				InsuredPersonId = viewModel.InsuredPersonID,
				//FirstName = viewModel.FirstName,
				//LastName = viewModel.LastName,
			};

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
