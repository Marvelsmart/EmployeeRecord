using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRecord.Data;
using EmployeeRecord.Models;
using EmployeeRecord.Services;

namespace WebApplication4.Pages
{
    public class EmployeeFormModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly Personalinfo _personalinfoService;

        public EmployeeFormModel(ApplicationDbContext context, Personalinfo personalinfoService)
        {
            _context = context;
            _personalinfoService = personalinfoService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // Get form values
                var firstname = Request.Form["firstname"].ToString();
                var middlename = Request.Form["middlename"].ToString();
                var lastname = Request.Form["lastname"].ToString();
                var othername = Request.Form["othername"].ToString();
                var gender = Request.Form["gender"].ToString();
                var dobStr = Request.Form["dob"].ToString();
                var maritalStatus = Request.Form["maritalStatus"].ToString();
                var nationality = Request.Form["nationality"].ToString();
                var stateOfOrigin = Request.Form["stateOfOrigin"].ToString();
                var lga = Request.Form["lga"].ToString();
                var ethnicity = Request.Form["ethnicity"].ToString();
                var religion = Request.Form["religion"].ToString();
                var phoneNO = Request.Form["phoneNO"].ToString();
                var alternatePhoneNO = Request.Form["alternatePhoneNO"].ToString();
                var email = Request.Form["email"].ToString();
                var address = Request.Form["address"].ToString();
                var city = Request.Form["city"].ToString();
                var state = Request.Form["state"].ToString();
                var country = Request.Form["country"].ToString();
                var postalcode = Request.Form["postalcode"].ToString();

                // Parse date from DD/MM/YYYY format
                DateTime.TryParseExact(dobStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob);

                // Create PersonalDetails object
                var personalDetails = new PersonalDetails
                {
                    Firstname = firstname ?? string.Empty,
                    Middlename = middlename ?? string.Empty,
                    Lastname = lastname ?? string.Empty,
                    Othername = othername,
                    GenderType = gender == "Male" ? Enums.GenderType.Male : Enums.GenderType.Female,
                    Dateofbirth = dob,
                    MaritalStatusType = maritalStatus switch
                    {
                        "Single" => Enums.MaritalStatusType.Single,
                        "Married" => Enums.MaritalStatusType.Married,
                        "Divorced" => Enums.MaritalStatusType.Divorced,
                        "Widowed" => Enums.MaritalStatusType.Widowed,
                        _ => Enums.MaritalStatusType.Single
                    },
                    Nationality = nationality ?? string.Empty,
                    StateOfOrigin = stateOfOrigin ?? string.Empty,
                    LGA = lga ?? string.Empty,
                    Ethnicity = ethnicity ?? string.Empty,
                    Religion = religion ?? string.Empty,
                    PhoneNO = phoneNO ?? string.Empty,
                    AlternatePhoneNO = alternatePhoneNO,
                    Email = email ?? string.Empty,
                    Address = address ?? string.Empty,
                    City = city ?? string.Empty,
                    State = state ?? string.Empty,
                    Country = country ?? string.Empty,
                    Postalcode = postalcode ?? string.Empty
                };

                // Add PersonalDetails
                await _personalinfoService.AddPersonalDetailsAsync(personalDetails);

                // Create IdDocuments object
                var nationalIdStr = Request.Form["nationalId"].ToString();
                var drivingLicenseStr = Request.Form["drivingLicenseNo"].ToString();
                var internationalPassportStr = Request.Form["internationalPassportNo"].ToString();
                var dateOfIssueStr = Request.Form["dateOfIssue"].ToString();
                var placeOfIssue = Request.Form["placeOfIssue"].ToString();
                var expiryDateStr = Request.Form["expiryDate"].ToString();

                int.TryParse(nationalIdStr, out int nationalId);
                int.TryParse(drivingLicenseStr, out int drivingLicense);
                int.TryParse(internationalPassportStr, out int internationalPassport);
                DateTime.TryParseExact(dateOfIssueStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateOfIssue);
                DateTime.TryParseExact(expiryDateStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime expiryDate);

                var idDocuments = new IdDocuments
                {
                    NationalId = nationalId,
                    DrivingLicenseNo = drivingLicense,
                    InternationalPassportNo = internationalPassport,
                    DateOfIssue = dateOfIssue,
                    PlaceOfIssue = placeOfIssue ?? string.Empty,
                    ExpiryDate = expiryDate
                };

                _context.IdDocuments.Add(idDocuments);
                await _context.SaveChangesAsync();

                // Create DemographicInfo object
                var heightStr = Request.Form["height"].ToString();
                var weight = Request.Form["weight"].ToString();
                var complexion = Request.Form["complexion"].ToString();
                var disabilityStr = Request.Form["disability"].ToString();
                var disabilityType = Request.Form["disabilityType"].ToString();
                var interests = Request.Form["interests"].ToString();

                float.TryParse(heightStr, out float height);
                bool disability = disabilityStr == "Yes";

                var demographicInfo = new DemographicInfo
                {
                    BloodGroupType = Request.Form["bloodGroup"].ToString() switch
                    {
                        "A+" => Enums.BloodGroupType.APositive,
                        "A-" => Enums.BloodGroupType.ANegative,
                        "B+" => Enums.BloodGroupType.BPositive,
                        "B-" => Enums.BloodGroupType.BNegative,
                        "AB+" => Enums.BloodGroupType.ABPositive,
                        "AB-" => Enums.BloodGroupType.ABNegative,
                        "O+" => Enums.BloodGroupType.OPositive,
                        "O-" => Enums.BloodGroupType.ONegative,
                        _ => Enums.BloodGroupType.OPositive
                    },
                    GenotypeType = Request.Form["genotype"].ToString() switch
                    {
                        "AA" => Enums.GenotypeType.AA,
                        "AS" => Enums.GenotypeType.AS,
                        "SS" => Enums.GenotypeType.SS,
                        "AC" => Enums.GenotypeType.AC,
                        "SC" => Enums.GenotypeType.SC,
                        _ => Enums.GenotypeType.AA
                    },
                    Disability = disability,
                    DisabilityType = disabilityType,
                    Height = height,
                    Weight = weight ?? string.Empty,
                    ComplexionType = complexion switch
                    {
                        "Fair" => Enums.ComplexionType.Fair,
                        "Light" => Enums.ComplexionType.Light,
                        "Medium" => Enums.ComplexionType.Medium,
                        "Dark" => Enums.ComplexionType.Dark,
                        _ => Enums.ComplexionType.Medium
                    },
                    Interest = interests
                };

                _context.DemographicInfo.Add(demographicInfo);
                await _context.SaveChangesAsync();

                return RedirectToPage("Index", new { message = "Employee record submitted successfully!" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error saving employee record: {ex.Message}");
                return Page();
            }
        }
    }
}
