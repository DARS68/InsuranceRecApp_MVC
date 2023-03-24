using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace pojisteni_FULL.Models.ViewModels
{
	public class InsuredPersonInsuraceViewModel
	{
		[Display(Name = "Název pojištění")]
		public string InsuranceName { get; set; }

		[Display(Name = "Popis")]
		public string InsuranceDescription { get; set; }

		[Display(Name = "Hodnota")]
		public int InsuranceAmount { get; set; }

		[Display(Name = "Předmět pojištění")]
		public string SubjectOfInsurance { get; set; }

		[Display(Name = "Platné od")]
		public DateTime ValidFrom { get; set; } = DateTime.Today.AddHours(23).AddMinutes(59);



		[Display(Name = "Platné do")]
		public DateTime ValidTo { get; set; } = DateTime.Today.AddHours(23).AddMinutes(59);

		[Display(Name = "Pojištěnec")]
		public int InsuredPersonId {get; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }

		// This must not be define if the model is used in a View 
		//public InsuredPersonInsuraceViewModel(InsuredPerson insuredPerson)
		//{
		//	InsuredPersonID = insuredPerson.InsuredPersonID;
		//	FirstName = insuredPerson.FirstName;
		//	LastName = insuredPerson.LastName;
		//}
    }
}
