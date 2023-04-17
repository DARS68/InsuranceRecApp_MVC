using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using pojisteni_FULL.Models.ViewModels.Items;

namespace pojisteni_FULL.Models.ViewModels
{
    /// <summary>
    /// ViewModel for InsuredPersons (used in Create, Delete, Edit)
    /// </summary>
    public class InsuredPersonViewModel
    {
        public InsuredPersonItem InsuredPersonItem { get; set; }
    }
}
