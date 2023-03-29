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
			return View(await DB.InsuredPerson.ToListAsync());
		}

		// GET: InsuredPersons/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || DB.InsuredPerson == null)
			{
				return NotFound();
			}

			var insuredPerson = await DB.InsuredPerson
				.Include(i => i.Insurances)
				.FirstOrDefaultAsync(m => m.InsuredPersonID == id);
			if (insuredPerson == null)
			{
				return NotFound();
			}

			TempData["InsuredPersonID"] = (int)insuredPerson.InsuredPersonID;

			return View(insuredPerson);
		}

		// GET: InsuredPersons/Create
		public IActionResult Create()
		{
			return View();
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
				// InsuredPerson data
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				Email = viewModel.Email,
				PhoneNumber = viewModel.PhoneNumber,
				StreetAndNumber = viewModel.StreetAndNumber,
				City = viewModel.City,
				ZipCode = viewModel.ZipCode
			};


			DB.InsuredPerson.Add(insuredPerson);

			await DB.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}


		// GET: InsuredPersons/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || DB.InsuredPerson == null)
			{
				return NotFound();
			}

			var insuredPerson = await DB.InsuredPerson.FindAsync(id);
			if (insuredPerson == null)
			{
				return NotFound();
			}

			InsuredPersonViewModel viewModel = new InsuredPersonViewModel
			{
				// InsuredPerson data
				InsuredPersonID = insuredPerson.InsuredPersonID,
				FirstName = insuredPerson.FirstName,
				LastName = insuredPerson.LastName,
				Email = insuredPerson.Email,
				PhoneNumber = insuredPerson.PhoneNumber,
				StreetAndNumber = insuredPerson.StreetAndNumber,
				City = insuredPerson.City,
				ZipCode = insuredPerson.ZipCode
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
				// InsuredPerson data
				InsuredPersonID = viewModel.InsuredPersonID,
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				Email = viewModel.Email,
				PhoneNumber = viewModel.PhoneNumber,
				StreetAndNumber = viewModel.StreetAndNumber,
				City = viewModel.City,
				ZipCode = viewModel.ZipCode
			};

			DB.InsuredPerson.Update(insuredPerson);
			await DB.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}


		// GET: InsuredPersons/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || DB.InsuredPerson == null)
			{
				return NotFound();
			}

			var insuredPerson = await DB.InsuredPerson
				.FirstOrDefaultAsync(m => m.InsuredPersonID == id);
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
			if (DB.InsuredPerson == null)
			{
				return Problem("Entity set 'ApplicationDbContext.InsuredPerson'  is null.");
			}
			var insuredPerson = await DB.InsuredPerson.FindAsync(id);
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
