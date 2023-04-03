using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using pojisteni_FULL.Models.ViewModels.Items;

namespace pojisteni_FULL.Models.ViewModels
{
    public class InsuredPersonViewModel
    {
        public InsuredPersonItem InsuredPersonItem { get; set; }

        // === Nahrazeno:  public InsuredPersonItem InsuredPersonItem { get; set; } == 
        //[Display(Name = "Pojištěnec")]
        //public int InsuredPersonID { get; set; }

        //[Display(Name = "Jméno")]
        //public string FirstName { get; set; }

        //[Display(Name = "Příjmení")]
        //public string LastName { get; set; }

        //[Display(Name = "Email")]
        //public string Email { get; set; } = "";

        //[Display(Name = "Telefonní číslo")]
        //public int PhoneNumber { get; set; }

        //[Display(Name = "Ulice a číslo popisné")]
        //public string StreetAndNumber { get; set; } = "";

        //[Display(Name = "Město")]
        //public string City { get; set; } = "";

        //[Display(Name = "PSČ")]
        //public string ZipCode { get; set; } = "";

        // This must not be define if the model is used in a View 
        //public InsuredPersonInsuraceViewModel(InsuredPersonItem insuredPerson)
        //{
        //	InsuredPersonID = insuredPerson.InsuredPersonID;
        //	FirstName = insuredPerson.FirstName;
        //	LastName = insuredPerson.LastName;
        //}
    }
}
