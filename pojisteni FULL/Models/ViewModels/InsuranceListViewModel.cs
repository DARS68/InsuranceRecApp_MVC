using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using pojisteni_FULL.Models.ViewModels.Items;

namespace pojisteni_FULL.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Insurances (used only in Index)
    /// </summary>
    public class InsuranceListViewModel
    {
        public List<InsuranceItem> InsuranceItems { get; set; }
	}
}
