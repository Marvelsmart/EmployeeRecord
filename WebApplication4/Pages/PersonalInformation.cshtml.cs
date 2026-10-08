using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRecord.Data;
using EmployeeRecord.Models;

namespace WebApplication4.Pages
{
    public class PersonalInformationModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PersonalInformationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(
            string firstName, string middleName, string lastName, string otherName,
            string gender, string dateOfBirth, string martialStatus, string nationality,
            string stateOfOrigin, string lga, string ethnicity, string religion,
            string phoneNumber, string alternatePhone, string emailAddress,
            string residentialAddress, string cityTown, string state, string country,
            string postalCode, string nationalID, string driversLicense, string passport,
            string dateOfIssue, string placeOfIssue, string expiryDate,
            string bloodGroup, string genotype, string hasDisability, string disabilityDetails,
            string height, string weight, string complexion, string hobbies,
            string employeeSignature, string declarationDate, 
            IFormFile photoFile)
        {
            try
            {
                // Parse dates
                DateTime dob = DateTime.TryParse(dateOfBirth.Replace("/", "-"), out var d) ? d : DateTime.Now;
                DateTime? issueDate = DateTime.TryParse(dateOfIssue?.Replace("/", "-"), out var id) ? id : (DateTime?)null;
                DateTime? expiry = DateTime.TryParse(expiryDate?.Replace("/", "-"), out var ed) ? ed : (DateTime?)null;

                var personalDetail = new PersonalDetails
                {
                    Firstname = firstName,
                    Middlename = middleName ?? "",
                    Lastname = lastName,
                    Othername = otherName,
                    GenderType = gender == "Male" ? Enums.GenderType.Male : Enums.GenderType.Female,
                    Dateofbirth = dob,
                    MaritalStatusType = martialStatus switch
                    {
                        "Married" => Enums.MaritalStatusType.Married,
                        "Divorced" => Enums.MaritalStatusType.Divorced,
                        "Widowed" => Enums.MaritalStatusType.Widowed,
                        _ => Enums.MaritalStatusType.Single
                    },
                    Nationality = nationality,
                    StateOfOrigin = stateOfOrigin,
                    LGA = lga,
                    Ethnicity = ethnicity,
                    Religion = religion,
                    PhoneNO = phoneNumber,
                    AlternatePhoneNO = alternatePhone,
                    Email = emailAddress,
                    Address = residentialAddress,
                    City = cityTown,
                    State = state,
                    Country = country,
                    Postalcode = postalCode,
                    NationalID = nationalID,
                    DriversLicense = driversLicense,
                    Passport = passport,
                    DateofIssue = issueDate,
                    PlaceofIssue = placeOfIssue,
                    ExpiryDate = expiry,
                    BloodGroup = bloodGroup,
                    Genotype = genotype,
                    HasDisability = hasDisability,
                    DisabilityDetails = disabilityDetails,
                    Height = string.IsNullOrEmpty(height) ? (int?)null : int.Parse(height),
                    Weight = string.IsNullOrEmpty(weight) ? (int?)null : int.Parse(weight),
                    Complexion = complexion,
                    Hobbies = hobbies
                };

                _context.PersonalDetails.Add(personalDetail);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Employee record saved successfully!";
                return RedirectToPage("/EmployeeReview");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error saving record: {ex.Message}");
                return Page();
            }
        }
    }
}
