namespace pojisteni_FULL.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string InsuranceName { get; set; } = "";
        public string InsuranceDescription { get; set; } = "";
        public int InsuranceAmount { get; set; }
        public string SubjectOfInsurance { get; set; } = "";
        public DateTime ValidFrom { get; set;} = DateTime.Now;
        public DateTime ValidTo { get; set; } = DateTime.Now;
    }
}
