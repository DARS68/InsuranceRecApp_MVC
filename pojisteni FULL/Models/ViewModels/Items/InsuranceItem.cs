using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace pojisteni_FULL.Models.ViewModels.Items
{
	[Display(Name = "Název pojištění")]
	public class InsuranceItem
	{
		public int InsuranceID { get; set; }

		[Display(Name = "Název pojištění")]
		public string InsuranceName { get; set; } = "";

		[Display(Name = "Popis")]
		public string InsuranceDescription { get; set; } = "";

		[Display(Name = "Pojistná částka")]
		public int InsuranceAmount { get; set; }

		[Display(Name = "Předmět pojištění")]
		public string SubjectOfInsurance { get; set; } = "";

		[Display(Name = "Platné od")]
		public DateTime ValidFrom { get; set; } = DateTime.Today.AddHours(24).AddMinutes(01);

		[Display(Name = "Platné do")]
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