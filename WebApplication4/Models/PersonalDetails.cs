namespace EmployeeRecord.Models
{
    public class PersonalDetails
    {
        public int Id { get; set; }
        public required string Firstname { get; set; }
        public required string Middlename { get; set; }
        public required string Lastname { get; set; }
        public string? Othername { get; set; }
        public Enums.GenderType GenderType { get; set; }
        public DateTime Dateofbirth { get; set; }
        public Enums.MaritalStatusType MaritalStatusType { get; set; }
        public required string Nationality { get; set; }
        public required string StateOfOrigin { get; set; }
        public required string LGA { get; set; }
        public required string Ethnicity { get; set; }
        public required string Religion { get; set; }
        public required string PhoneNO { get; set; }
        public string? AlternatePhoneNO { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
        public required string Postalcode { get; set; }

        // Identification Documents
        public string? NationalID { get; set; }
        public string? DriversLicense { get; set; }
        public string? Passport { get; set; }
        public DateTime? DateofIssue { get; set; }
        public string? PlaceofIssue { get; set; }
        public DateTime? ExpiryDate { get; set; }

        // Demographic Information
        public string? BloodGroup { get; set; }
        public string? Genotype { get; set; }
        public string? HasDisability { get; set; }
        public string? DisabilityDetails { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string? Complexion { get; set; }
        public string? Hobbies { get; set; }
    }

}
