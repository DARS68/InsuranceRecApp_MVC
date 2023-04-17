using pojisteni_FULL.Models.ViewModels.Items;

namespace pojisteni_FULL.Models.ViewModels
{
    public class InsuredPersonListViewModel
    {
		/// <summary>
		/// ViewModel for InsuredPersons - LIST (used in Index)
		/// 
		/// </summary>
		public List<InsuredPersonItem> InsuredPersonItems { get; set; }
        public int pocet { get; set; }
	}
}
