using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using pojisteni_FULL.Models;

namespace pojisteni_FULL.Models.ViewModels.Items
{
    // Toto není databázová tabulka, pouze se na instanci
    // této třídy databázová tabulka mapuje
    public class InsuredPersonItem
    {
        [Display(Name = "Pojištěnec ID")]
        public int InsuredPersonID { get; set; }

        [Display(Name = "Jméno")]
		[Required(ErrorMessage = "Vyplňte jméno")]
        public string FirstName { get; set; }
		
		[Display(Name = "Příjmení")]
        [Required(ErrorMessage = "Vyplňte příjmení")]
        public string LastName { get; set; }

		[Display(Name = "Email")]
		[Required(ErrorMessage = "Vyplňte kontaktní email")]
        public string Email { get; set; } = "";

        [Display(Name = "Telefonní číslo")]
        [Required(ErrorMessage = "Vyplňte kontaktní mobilní telefon")]
        public int PhoneNumber { get; set; } = 0;

        [Display(Name = "Ulice a číslo popisné")]
		[Required(ErrorMessage = "Vyplňte adresu")]
		public string StreetAndNumber { get; set; } = "";

        [Display(Name = "Město")]
		[Required(ErrorMessage = "Vyplňte město")]
		public string City { get; set; } = "";

        [Display(Name = "PSČ")]
		[Required(ErrorMessage = "Vyplňte PSČ")]
		[RegularExpression("^\\d{3} ?\\d{2}$", ErrorMessage = "Zadejte prosím validní PSČ")]
		[StringLength(6, MinimumLength = 5)]
		public string ZipCode { get; set; } = "";

        public static InsuredPersonItem GetInsuredPersonItem(InsuredPerson dbPerson)
        {
            return new InsuredPersonItem
            {
                InsuredPersonID = dbPerson.InsuredPersonID,
                FirstName = dbPerson.FirstName,
                LastName = dbPerson.LastName,
                Email = dbPerson.Email,
                PhoneNumber = dbPerson.PhoneNumber,
                StreetAndNumber = dbPerson.StreetAndNumber,
                City = dbPerson.City,
                ZipCode = dbPerson.ZipCode
            };
        }
    }
}
