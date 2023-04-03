using pojisteni_FULL.Models.ViewModels.Items;

namespace pojisteni_FULL.Models.ViewModels
{
    public class InsuredPersonInsuranceListViewModel
	{
        public InsuredPersonItem InsuredPersonItem { get; set; }

        public List<InsuranceItem> InsuranceItems { get; set; }
    }
}
