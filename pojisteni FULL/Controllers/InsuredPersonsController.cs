using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    public class InsuredPersonsController : Controller
	{
		private readonly ApplicationDbContext DB;

		public InsuredPersonsController(ApplicationDbContext context)
		{
			DB = context;
		}

		// GET: InsuredPersons
		public async Task<IActionResult> Index()
		{
			InsuredPersonListViewModel viewModel = new InsuredPersonListViewModel
			{
				InsuredPersonItems = DB.InsuredPerson.Select((InsuredPerson i) => InsuredPersonItem.GetInsuredPersonItem(i)).ToList()
			};

			return View(viewModel);
		}

		// GET: InsuredPersons/Details/5
		//public async Task<IActionResult> Details(int? id)
		//{
		//	//OK
		//	if (id == null || DB.InsuredPersonItem == null)
		//	{
		//		return NotFound();
		//	}

		//	InsuredPersonItem insuredPerson = await DB.InsuredPersonItem
		//		.Include(i => i.InsuranceItems)
		//		.FirstOrDefaultAsync(m => m.InsuredPersonID == id);

		//	//OK
		//	if (insuredPerson == null)
		//	{
		//		return NotFound();
		//	}

		//	int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

		//	// Keep TempData alive
		//	TempData.Keep();
		//	List<Insurance> insurance = new List<Insurance>();
		//		insurance.Add(new DB.Insurance.Find(insuredPersonId));
		//	//TempData["InsuredPersonID"] = (int)insuredPerson.InsuredPersonID;

		//	InsuredPersonViewModel viewModel = new InsuredPersonViewModel
		//	{
		//		InsuredPersonID = insuredPerson.InsuredPersonID,
		//		FirstName = insuredPerson.FirstName,
		//		LastName = insuredPerson.LastName,
		//		Email = insuredPerson.Email,
		//		PhoneNumber = insuredPerson.PhoneNumber,
		//		StreetAndNumber = insuredPerson.StreetAndNumber,
		//		City = insuredPerson.City,
		//		ZipCode = insuredPerson.ZipCode,
		//		InsuranceID = insurance.InsuranceID,
		//		InsuranceName = insurance.InsuranceName,
		//		InsuranceAmount = insurance.InsuranceAmount

		//	};

		//	return View(viewModel);
		//}

		// GET: InsuredPersons/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			/*if (id == null || DB.InsuredPersonItem == null)
			{
				return NotFound();
			}

			InsuredPersonItem insuredPerson = await DB.InsuredPersonItem
				.Include(i => i.InsuranceItems)
				.FirstOrDefaultAsync(m => m.InsuredPersonID == id);
			if (insuredPerson == null)
			{
				return NotFound();
			}

			TempData["InsuredPersonID"] = (int)insuredPerson.InsuredPersonID;
			*/

			InsuredPerson insuredPerson = DB.InsuredPerson.FirstOrDefault(p => p.InsuredPersonID == id);

			if (insuredPerson.IsNull()) // if (insurance == null) or if (insurance is null)
			{
				return NotFound();
			}

			InsuredPersonInsuranceListViewModel viewModel = new InsuredPersonInsuranceListViewModel
			{
				InsuredPersonItem = InsuredPersonItem.GetInsuredPersonItem(insuredPerson),
				InsuranceItems = insuredPerson.Insurances.Select(i => InsuranceItem.GetInsuranceItem(i)).ToList()
			};

			return View(viewModel);
			//return View(insuredPerson);
		}

		// GET: InsuredPersons/Create
		public IActionResult Create()
		{
			//if (insuredPerson.IsNull()) // if (insurance == null) or if (insurance is null)
			//{
			//	return View();
			//	// Considet this: return NotFound();
			//}

			InsuredPersonInsuranceViewModel viewModel = new InsuredPersonInsuranceViewModel
			{
				//InsuranceItem = new InsuranceItem(),
				InsuredPersonItem = new InsuredPersonItem()
			};

			return View(viewModel);
			//return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(InsuredPersonViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			InsuredPerson insuredPerson = new InsuredPerson
			{
				// InsuredPersonItem data
				FirstName = viewModel.InsuredPersonItem.FirstName,
				LastName = viewModel.InsuredPersonItem.LastName,
				Email = viewModel.InsuredPersonItem.Email,
				PhoneNumber = viewModel.InsuredPersonItem.PhoneNumber,
				StreetAndNumber = viewModel.InsuredPersonItem.StreetAndNumber,
				City = viewModel.InsuredPersonItem.City,
				ZipCode = viewModel.InsuredPersonItem.ZipCode
			};


			DB.InsuredPerson.Add(insuredPerson);

			await DB.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}


		// GET: InsuredPersons/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			InsuredPerson insuredPerson = DB.InsuredPerson.FirstOrDefault(p => p.InsuredPersonID == id);

			if (insuredPerson.IsNull()) // if (insurance == null) or if (insurance is null)
			{
				return NotFound();
			}

			InsuredPersonInsuranceListViewModel viewModel = new InsuredPersonInsuranceListViewModel
			{
				InsuredPersonItem = InsuredPersonItem.GetInsuredPersonItem(insuredPerson),
				//InsuranceItems = insuredPerson.Insurances.Select(i => InsuranceItem.GetInsuranceItem(i)).ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(InsuredPersonViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			InsuredPerson insuredPerson = new InsuredPerson
			{
				// InsuredPersonItem data
				InsuredPersonID = viewModel.InsuredPersonItem.InsuredPersonID,
				FirstName = viewModel.InsuredPersonItem.FirstName,
				LastName = viewModel.InsuredPersonItem.LastName,
				Email = viewModel.InsuredPersonItem.Email,
				PhoneNumber = viewModel.InsuredPersonItem.PhoneNumber,
				StreetAndNumber = viewModel.InsuredPersonItem.StreetAndNumber,
				City = viewModel.InsuredPersonItem.City,
				ZipCode = viewModel.InsuredPersonItem.ZipCode
			};

			DB.InsuredPerson.Update(insuredPerson);
			await DB.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}


		// GET: InsuredPersons/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			//if (id == null || DB.InsuredPerson == null)
			//{
			//	return NotFound();
			//}

			//var insuredPerson = await DB.InsuredPerson
			//	.FirstOrDefaultAsync(m => m.InsuredPersonID == id);
			//if (insuredPerson == null)
			//{
			//	return NotFound();
			//}

			//return View(insuredPerson);

			InsuredPerson insuredPerson = DB.InsuredPerson.FirstOrDefault(p => p.InsuredPersonID == id);

			if (insuredPerson.IsNull()) // if (insurance == null) or if (insurance is null)
			{
				return NotFound();
			}

			InsuredPersonInsuranceListViewModel viewModel = new InsuredPersonInsuranceListViewModel
			{
				InsuredPersonItem = InsuredPersonItem.GetInsuredPersonItem(insuredPerson),
				//InsuranceItems = insuredPerson.Insurances.Select(i => InsuranceItem.GetInsuranceItem(i)).ToList()
			};

			return View(viewModel);
		}

		// POST: InsuredPersons/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(InsuredPersonViewModel viewModel)
		{
			//if (DB.InsuredPerson == null)
			//{
			//	return Problem("Entity set 'ApplicationDbContext.InsuredPersonItem'  is null.");
			//}
			//var insuredPerson = await DB.InsuredPerson.FindAsync(id);

			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			InsuredPerson insuredPerson = new InsuredPerson
			{
				// InsuredPersonItem data
				InsuredPersonID = viewModel.InsuredPersonItem.InsuredPersonID,
				FirstName = viewModel.InsuredPersonItem.FirstName,
				LastName = viewModel.InsuredPersonItem.LastName,
				Email = viewModel.InsuredPersonItem.Email,
				PhoneNumber = viewModel.InsuredPersonItem.PhoneNumber,
				StreetAndNumber = viewModel.InsuredPersonItem.StreetAndNumber,
				City = viewModel.InsuredPersonItem.City,
				ZipCode = viewModel.InsuredPersonItem.ZipCode
			};

				if (insuredPerson != null)
			{
				DB.InsuredPerson.Remove(insuredPerson);
			}

			await DB.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool InsuredPersonExists(int id)
		{
			return DB.InsuredPerson.Any(e => e.InsuredPersonID == id);
		}
	}
}
