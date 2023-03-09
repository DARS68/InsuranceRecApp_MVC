namespace pojisteni_FULL.Models
{
    public class InsuredPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Email { get; set; }
        public int PhoneNumber { get; set; }
        public string StreetAndNumber { get; set; } = "";
        public string City { get; set; } = "";
        public string ZipCode { get; set; } = "";

    }
}
