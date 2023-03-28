using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace pojisteni_FULL.Models.ViewModels
{
	public class InsuranceListViewModel
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
		public DateTime ValidFrom { get; set; } = DateTime.Now;

		[Display(Name = "Platné do")]
		public DateTime ValidTo { get; set; } = DateTime.Now;

		// Navigation - Relation 1:N between entities InsuredPerson <-- Insurance
		[Display(Name = "Pojištěnec")]
		public int InsuredPersonId { get; set; }

		public InsuranceListViewModel(int insuranceAmount, string subjectOfInsurance, int insuredPersonId)
		{
			InsuranceAmount = insuranceAmount;
			SubjectOfInsurance = subjectOfInsurance;
			InsuredPersonId = insuredPersonId;
		}
	}
	
	
}
