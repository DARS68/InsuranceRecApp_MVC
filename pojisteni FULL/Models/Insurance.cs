using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pojisteni_FULL.Models
{
	public class Insurance
	{
		public int InsuranceID { get; set; }
	
		public string InsuranceName { get; set; } = "";

		public string InsuranceDescription { get; set; } = "";
		
		public int InsuranceAmount { get; set; }
		
		public string SubjectOfInsurance { get; set; } = "";
		
		public DateTime ValidFrom { get; set; } = DateTime.Now;

		public DateTime ValidTo { get; set; } = DateTime.Now;

		// Navigation - Relation 1:N between entities InsuredPersonItem <-- Insurance
		[Display(Name = "Pojištěnec")]
		public int InsuredPersonId { get; set; }  // Foreign key to entity InsuredPersonItem

		// Virtual = won´t be in DB table
		public virtual InsuredPerson InsuredPerson { get; set; }  // Link to InsuredPersonItem




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
