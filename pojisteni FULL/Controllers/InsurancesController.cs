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


			//List<InsuranceListViewModel> viewModel = new List<InsuranceListViewModel>();
			//viewModel = await DB.Insurance.ToListAsync();

			//return View(viewModel);
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
			
			int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

			// Keep TempData alive
			TempData.Keep();
			InsuredPerson insuredPerson = DB.InsuredPerson.Find(insuredPersonId);
		

			if (insurance == null)
			{
				return NotFound();
			}

			InsuranceViewModel viewModel = new InsuranceViewModel
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
			InsuranceViewModel viewModel = new InsuranceViewModel
			{
				InsuredPersonID = insuredPerson.InsuredPersonID,
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
		public async Task<IActionResult> Create(InsuranceViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			InsuredPerson insuredPerson = DB.InsuredPerson.Find(viewModel.InsuredPersonID);

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
			int insuredPersonId = Convert.ToInt32(TempData["InsuredPersonID"].ToString());

			// Keep TempData alive
			TempData.Keep();
			InsuredPerson insuredPerson = DB.InsuredPerson.Find(insuredPersonId);

			InsuranceViewModel viewModel = new InsuranceViewModel
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
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(InsuranceViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			InsuredPerson insuredPerson = DB.InsuredPerson.Find(viewModel.InsuredPersonID);

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

		// GET: Insurances/Delete/5
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

			InsuranceViewModel viewModel = new InsuranceViewModel
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


		// POST: Insurances/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(InsuranceViewModel viewModel)
		{
			if (DB.Insurance == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Insurance'  is null.");
			}
			
			//InsuredPerson insuredPerson = DB.InsuredPerson.Find(insuredPersonId);

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

			//var insurance = await DB.Insurance.FindAsync(id);
			
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
