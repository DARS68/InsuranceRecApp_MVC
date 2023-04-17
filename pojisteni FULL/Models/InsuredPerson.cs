using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace pojisteni_FULL.Models
{
	/// <summary>
	/// InsuredPerson is used as database class
	/// </summary>
	public class InsuredPerson
	{
		public int InsuredPersonID { get; set; }

		public string FirstName { get; set; } = "";

		public string LastName { get; set; } = "";

		public string Email { get; set; } = "";

		public int PhoneNumber { get; set; }
		
		public string StreetAndNumber { get; set; } = "";
		
		public string City { get; set; } = "";
		
		public string ZipCode { get; set; } = "";


		public virtual ICollection<Insurance> Insurances { get; set; } = new HashSet<Insurance>();
		//public virtual Insurance Insurances { get; set; }  // Link to InsuranceItem


	}
}
