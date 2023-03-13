using System.ComponentModel.DataAnnotations;

namespace pojisteni_FULL.Models
{
    public class Insurance
    {
        public int Id { get; set; }
		[Display(Name = "Název pojištění")]
		public string InsuranceName { get; set; } = "";

		[Display(Name = "Popis")] 
        public string InsuranceDescription { get; set; } = "";
		[Display(Name = "Hodnota")]
		public int InsuranceAmount { get; set; }
		[Display(Name = "Předmět pojištěnní")]
		public string SubjectOfInsurance { get; set; } = "";
		[Display(Name = "Platné od")]
		public DateTime ValidFrom { get; set;} = DateTime.Now;
        [Display(Name = "Platné do")] 
		public DateTime ValidTo { get; set; } = DateTime.Now;
    }
}
