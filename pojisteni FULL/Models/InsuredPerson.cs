using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace pojisteni_FULL.Models
{
	public class InsuredPerson
	{
		public int InsuredPersonID { get; set; }

		[Display(Name = "Jméno")]
		public string FirstName { get; set; } = "";

		[Display(Name = "Příjmení")]
		public string LastName { get; set; } = "";

		[Display(Name = "Email___")]
		public string Email { get; set; } = "";

		[Display(Name = "Telefonní číslo")]
		public int PhoneNumber { get; set; }
		
		[Display(Name = "Ulice a číslo popisné")]
		public string StreetAndNumber { get; set; } = "";
		
		[Display(Name = "Město")]
		public string City { get; set; } = "";
		
		[Display(Name = "PSČ")]
		public string ZipCode { get; set; } = "";


		public virtual ICollection<Insurance> Insurances { get; set; } = new HashSet<Insurance>();

	}
}
