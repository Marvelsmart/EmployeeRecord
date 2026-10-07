namespace EmployeeRecord.Models
{
    public class IdDocuments
    {
        public int Id { get; set; }
        public required int NationalId { get; set; }
        public required int DrivingLicenseNo { get; set; }
        public required int InternationalPassportNo { get; set; }
        public required DateTime DateOfIssue { get; set; }
        public required string PlaceOfIssue { get; set; }
        public required DateTime ExpiryDate { get; set; }
    }
}
