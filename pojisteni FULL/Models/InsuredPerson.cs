using System.ComponentModel.DataAnnotations;

namespace pojisteni_FULL.Models
{
	public class InsuredPerson
	{
		public int Id { get; set; }

		[Display(Name = "Jméno")]
		public string FirstName { get; set; } = "";
		[Display(Name = "Příjmení")]
		public string LastName { get; set; } = "";
		public string Email { get; set; }
		[Display(Name = "Telefonní číslo")]
		public int PhoneNumber { get; set; }
		[Display(Name = "Ulice a číslo popisné")]
		public string StreetAndNumber { get; set; } = "";
		[Display(Name = "Město")] 
		public string City { get; set; } = "";
		[Display(Name = "PSČ")]
		public string ZipCode { get; set; } = "";

	}
}
