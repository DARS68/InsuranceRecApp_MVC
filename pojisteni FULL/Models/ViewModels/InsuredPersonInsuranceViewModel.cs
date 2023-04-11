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
	}
}
