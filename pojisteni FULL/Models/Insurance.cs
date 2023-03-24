using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pojisteni_FULL.Models
{
	public class Insurance
	{
		public int InsuranceID { get; set; }
		[Display(Name = "Název pojištění")]
		public string InsuranceName { get; set; } = "";

		[Display(Name = "Popis")]
		public string InsuranceDescription { get; set; } = "";
		[Display(Name = "Hodnota")]
		public int InsuranceAmount { get; set; }
		[Display(Name = "Předmět pojištění")]
		public string SubjectOfInsurance { get; set; } = "";
		[Display(Name = "Platné od")]
		public DateTime ValidFrom { get; set; } = DateTime.Now;

		[Display(Name = "Platné do")]
		public DateTime ValidTo { get; set; } = DateTime.Now;

		// Navigation - Relation 1:N between entities InsuredPerson <-- Insurance
		[Display(Name = "Pojištěnec")]
		public int InsuredPersonId { get; set; }  // Foreign key to entity InsuredPerson

		// Virtual = won´t be in DB table
		public virtual InsuredPerson InsuredPerson { get; set; }  // Link to InsuredPerson






		public static List<SelectListItem> GetInsuranceTypes()
		{
			var insuranceTypes = new List<SelectListItem>();
			insuranceTypes.Add(new SelectListItem { Text = "Pojištění osob", Value = "Pojištění osob", Selected = true });
			insuranceTypes.Add(new SelectListItem { Text = "Pojištění majetku", Value = "Pojištění majetku" });
			insuranceTypes.Add(new SelectListItem { Text = "Pojištění vozidel", Value = "Pojištění vozidel" });
			insuranceTypes.Add(new SelectListItem { Text = "Životní pojištění", Value = "Životní pojištění" });
			return insuranceTypes;
		}

	}


}
