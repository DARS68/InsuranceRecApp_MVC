using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace pojisteni_FULL.Models.ViewModels.Items
{
    // TOto není databázová tabulka, pouze se na instanci
    // této třídy databázová tabulka mapuje
    public class InsuredPersonItem
    {
        [Display(Name = "Pojištěnec")]
        public int InsuredPersonID { get; set; }

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
