using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using pojisteni_FULL.Models.ViewModels.Items;

namespace pojisteni_FULL.Models.ViewModels
{
    public class InsuranceListViewModel
    {
        public List<InsuranceItem> InsuranceItems { get; set; }
		public InsuranceItem InsuranceItem { get; set; }
		public InsuredPersonItem InsuredPersonItem { get; set; }
	}
}
