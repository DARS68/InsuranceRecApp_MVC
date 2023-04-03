using Microsoft.AspNetCore.Mvc.Rendering;
using pojisteni_FULL.Models.ViewModels.Items;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace pojisteni_FULL.Models.ViewModels
{
    public class InsuredPersonInsuranceViewModel
    {
        public InsuranceItem InsuranceItem { get; set; }
        

        public InsuredPersonItem InsuredPersonItem { get; set; }

        // === Nahrazeno public InsuranceItem InsuraceItem { get; set; } ===
        //public int InsuranceID { get; set; }

        //[Display(Name = "Název pojištění")]
        //public string InsuranceName { get; set; }

        //[Display(Name = "Popis")]
        //public string InsuranceDescription { get; set; }

        //[Display(Name = "Pojistná částka")]
        //public int InsuranceAmount { get; set; }

        //[Display(Name = "Předmět pojištění")]
        //public string SubjectOfInsurance { get; set; }

        //[Display(Name = "Platné od")]
        //[DataType(DataType.DateTime)]  // DateTime limits only to Date
        //public DateTime ValidFrom { get; set; } = DateTime.Today.AddHours(24).AddMinutes(01);

        //[Display(Name = "Platné do")]
        //[DataType(DataType.DateTime)]  // DateTime limits only to Date
        //public DateTime ValidTo { get; set; } = DateTime.Today.AddHours(23).AddMinutes(59);

        // === Nahrazeno public InsuredPersonItem InsuredPersonItem { get; set; } ===
        //[Display(Name = "Pojištěnec")]
        //public int InsuredPersonID { get; set; }

        //[Display(Name = "Jméno")]
        //public string FirstName { get; set; }

        //[Display(Name = "Příjmení")]
        //public string LastName { get; set; }



        // This must not be define if the model is used in a View 
        //public InsuredPersonInsuraceViewModel(InsuredPersonItem insuredPerson)
        //{
        //	InsuredPersonID = insuredPerson.InsuredPersonID;
        //	FirstName = insuredPerson.FirstName;
        //	LastName = insuredPerson.LastName;
        //}
    }
}
