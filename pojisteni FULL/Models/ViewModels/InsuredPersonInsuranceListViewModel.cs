using pojisteni_FULL.Models.ViewModels.Items;

namespace pojisteni_FULL.Models.ViewModels
{
	/// <summary>
	/// ViewModel for InsuredPersons - LIST (used only in Detail, 
	/// because detail includes Person and his insurances)
	/// </summary>
	public class InsuredPersonInsuranceListViewModel
	{
		public InsuredPersonItem InsuredPersonItem { get; set; }

		public List<InsuranceItem> InsuranceItems { get; set; }


	}
}
