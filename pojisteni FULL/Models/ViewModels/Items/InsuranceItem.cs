using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace pojisteni_FULL.Models.ViewModels.Items
{
	public class InsuranceItem
	{
		[Display(Name = "Pojištění ID")]
	
		public int InsuranceID { get; set; }

		[Display(Name = "Název pojištění")]
		[Required(ErrorMessage = "Vyberte název pojištění ze seznamu")]
		public string InsuranceName { get; set; } = "";

		[Display(Name = "Popis")]
		[Required(ErrorMessage = "Vyplňte stručný popis")]
		public string InsuranceDescription { get; set; } = "";

		[Display(Name = "Pojistná částka")]
		[Required(ErrorMessage = "Vyplňte pojistnou částku")]
		public int InsuranceAmount { get; set; } = 0;

		[Display(Name = "Předmět pojištění")]
		[Required(ErrorMessage = "Vyplňte, co je předmětem pojištění")]
		public string SubjectOfInsurance { get; set; } = "";

		[Display(Name = "Platné od")]
		[Required(ErrorMessage = "Upravte začátek platnosti")]
		public DateTime ValidFrom { get; set; } = DateTime.Today.AddHours(24).AddMinutes(01);

		[Display(Name = "Platné do")]
		[Required(ErrorMessage = "Upravte konec platnosti")]
		public DateTime ValidTo { get; set; } = DateTime.Today.AddYears(1).AddHours(23).AddMinutes(59);

		[Display(Name = "Pojištěnec ID")]
		public int InsuredPersonId { get; set; }  // Foreign key to entity InsuredPersonItem

		[Display(Name = "Jméno, Příjmení")]
		public string InsuredPersonName { get; set; }

		[Display(Name = "Ulice + ČP, Město")]
		public string InsuredPersonStreetNumberCity { get; set; }

		public static InsuranceItem GetInsuranceItem(Insurance dbInsurance)
		{
			return new InsuranceItem
			{
				InsuranceID = dbInsurance.InsuranceID,
				InsuranceName = dbInsurance.InsuranceName,
				InsuranceDescription = dbInsurance.InsuranceDescription,
				InsuranceAmount = dbInsurance.InsuranceAmount,
				SubjectOfInsurance = dbInsurance.SubjectOfInsurance,
				ValidFrom = dbInsurance.ValidFrom,
				ValidTo = dbInsurance.ValidTo,
				InsuredPersonId = dbInsurance.InsuredPersonId,
				InsuredPersonName = $"{dbInsurance.InsuredPerson.FirstName} {dbInsurance.InsuredPerson.LastName}",
				InsuredPersonStreetNumberCity = $"{dbInsurance.InsuredPerson.StreetAndNumber}, {dbInsurance.InsuredPerson.City}"

			};
		}

		//list of Insurance names, it is used in web form, new insurance
		public static List<SelectListItem> GetInsuranceNames()
		{
			var insuranceNames = new List<SelectListItem>();
			insuranceNames.Add(new SelectListItem { Text = "Pojištění osob", Value = "Pojištění osob", Selected = true });
			insuranceNames.Add(new SelectListItem { Text = "Pojištění majetku", Value = "Pojištění majetku" });
			insuranceNames.Add(new SelectListItem { Text = "Pojištění vozidel", Value = "Pojištění vozidel" });
			insuranceNames.Add(new SelectListItem { Text = "Životní pojištění", Value = "Životní pojištění" });
			return insuranceNames;
		}
	}
}