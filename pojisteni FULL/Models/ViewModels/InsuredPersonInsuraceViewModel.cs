using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace pojisteni_FULL.Models.ViewModels
{
	public class InsuredPersonInsuraceViewModel
	{
		[Display(Name = "Typ pojištění")]
		public string InsuranceName { get; set; }

		[Display(Name = "Popis")]
		public string InsuranceDescription { get; set; }

		[Display(Name = "Pojistná částka")]
		public int InsuranceAmount { get; set; }

		[Display(Name = "Předmět pojištění")]
		public string SubjectOfInsurance { get; set; }

		[Display(Name = "Platné od")]
		[DataType(DataType.DateTime)]  // DateTime limits only to Date
		public DateTime ValidFrom { get; set; } = DateTime.Today.AddHours(24).AddMinutes(01);

		[Display(Name = "Platné do")]
		[DataType(DataType.DateTime)]  // DateTime limits only to Date
		public DateTime ValidTo { get; set; } = DateTime.Today.AddHours(23).AddMinutes(59);

		[Display(Name = "Pojištěnec")]
		public int InsuredPersonId { get; set; }

		[Display(Name = "Jméno")]
		public string FirstName { get; set; }

		[Display(Name = "Příjmení")]
		public string LastName { get; set; }

		[Display(Name = "Email")]
		public string Email { get; set; } = "";

		[Display(Name = "Telefonní číslo")]
		public int PhoneNumber { get; set; }

		[Display(Name = "Ulice a číslo popisné")]
		public string StreetAndNumber { get; set; } = "";

		[Display(Name = "Město")]
		public string City { get; set; } = "";

		[Display(Name = "PSČ")]
		public string ZipCode { get; set; } = "";

		// This must not be define if the model is used in a View 
		//public InsuredPersonInsuraceViewModel(InsuredPerson insuredPerson)
		//{
		//	InsuredPersonID = insuredPerson.InsuredPersonID;
		//	FirstName = insuredPerson.FirstName;
		//	LastName = insuredPerson.LastName;
		//}
	}
}
