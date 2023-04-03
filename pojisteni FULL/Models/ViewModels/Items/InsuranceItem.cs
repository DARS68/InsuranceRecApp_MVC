using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace pojisteni_FULL.Models.ViewModels.Items
{
    public class InsuranceItem
    {
        public int InsuranceID { get; set; }

        [Display(Name = "Název pojištění")]
        public string InsuranceName { get; set; } = "";

        [Display(Name = "Popis")]
        public string InsuranceDescription { get; set; } = "";

        [Display(Name = "Pojistná částka")]
        public int InsuranceAmount { get; set; }

        [Display(Name = "Předmět pojištění")]
        public string SubjectOfInsurance { get; set; } = "";

        [Display(Name = "Platné od")]
        public DateTime ValidFrom { get; set; } = DateTime.Today.AddHours(24).AddMinutes(01);

        [Display(Name = "Platné do")]
        public DateTime ValidTo { get; set; } = DateTime.Today.AddHours(23).AddMinutes(59);


        public static InsuranceItem GetInsuranceItem(Insurance dbInsurance)
        {
            return new InsuranceItem
            {
                InsuranceID = dbInsurance.InsuranceID,
                InsuranceName = dbInsurance.InsuranceName,
                InsuranceDescription = dbInsurance.InsuranceDescription,
                InsuranceAmount = dbInsurance.InsuranceAmount,
                SubjectOfInsurance = dbInsurance.SubjectOfInsurance,
                ValidFrom = dbInsurance.ValidFrom,
                ValidTo = dbInsurance.ValidTo,
                //Fullname = dbInsurance.InsuredPerson"${FirstName }"
			};
        }
    }
}
