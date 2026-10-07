using WebApplication4.Models;

namespace EmployeeRecord.Models
{
    public class DemographicInfo
    {
        public int Id { get; set; }
        public required Enums.BloodGroupType BloodGroupType { get; set; }
        public required Enums.GenotypeType GenotypeType { get; set; }
        public required bool Disability { get; set; }
        public string? DisabilityType { get; set; }
        public required float Height { get; set; }
        public required string Weight { get; set; }
        public required Enums.ComplexionType ComplexionType { get; set; }
        public string? Interest { get; set; }
    }
}
