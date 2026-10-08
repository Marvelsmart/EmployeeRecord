using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRecord.Data;
using EmployeeRecord.Models;

namespace WebApplication4.Pages
{
    public class EditEmployeeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditEmployeeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PersonalDetails? Employee { get; set; }

        public async Task OnGetAsync(int id)
        {
            Employee = _context.PersonalDetails.FirstOrDefault(e => e.Id == id);
        }

        public async Task<IActionResult> OnPostAsync(int id,
            string firstName, string middleName, string lastName, string otherName,
            string gender, string dateOfBirth, string martialStatus, string nationality,
            string stateOfOrigin, string lga, string ethnicity, string religion,
            string phoneNumber, string alternatePhone, string emailAddress,
            string residentialAddress, string cityTown, string state, string country,
            string postalCode, string nationalID, string driversLicense, string passport,
            string dateOfIssue, string placeOfIssue, string expiryDate,
            string bloodGroup, string genotype, string hasDisability, string disabilityDetails,
            string height, string weight, string complexion, string hobbies)
        {
            try
            {
                var employee = _context.PersonalDetails.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    TempData["ErrorMessage"] = "Employee not found.";
                    return RedirectToPage("/EmployeeReview");
                }

                // Parse dates
                DateTime dob = DateTime.TryParse(dateOfBirth.Replace("/", "-"), out var d) ? d : employee.Dateofbirth;
                DateTime? issueDate = DateTime.TryParse(dateOfIssue?.Replace("/", "-"), out var id_date) ? id_date : (DateTime?)null;
                DateTime? expiry = DateTime.TryParse(expiryDate?.Replace("/", "-"), out var ed) ? ed : (DateTime?)null;

                // Update employee details
                employee.Firstname = firstName;
                employee.Middlename = middleName ?? "";
                employee.Lastname = lastName;
                employee.Othername = otherName;
                employee.GenderType = gender == "Male" ? Enums.GenderType.Male : Enums.GenderType.Female;
                employee.Dateofbirth = dob;
                employee.MaritalStatusType = martialStatus switch
                {
                    "Married" => Enums.MaritalStatusType.Married,
                    "Divorced" => Enums.MaritalStatusType.Divorced,
                    "Widowed" => Enums.MaritalStatusType.Widowed,
                    _ => Enums.MaritalStatusType.Single
                };
                employee.Nationality = nationality;
                employee.StateOfOrigin = stateOfOrigin;
                employee.LGA = lga;
                employee.Ethnicity = ethnicity;
                employee.Religion = religion;
                employee.PhoneNO = phoneNumber;
                employee.AlternatePhoneNO = alternatePhone;
                employee.Email = emailAddress;
                employee.Address = residentialAddress;
                employee.City = cityTown;
                employee.State = state;
                employee.Country = country;
                employee.Postalcode = postalCode;
                employee.NationalID = nationalID;
                employee.DriversLicense = driversLicense;
                employee.Passport = passport;
                employee.DateofIssue = issueDate;
                employee.PlaceofIssue = placeOfIssue;
                employee.ExpiryDate = expiry;
                employee.BloodGroup = bloodGroup;
                employee.Genotype = genotype;
                employee.HasDisability = hasDisability;
                employee.DisabilityDetails = disabilityDetails;
                employee.Height = string.IsNullOrEmpty(height) ? (int?)null : int.Parse(height);
                employee.Weight = string.IsNullOrEmpty(weight) ? (int?)null : int.Parse(weight);
                employee.Complexion = complexion;
                employee.Hobbies = hobbies;

                _context.PersonalDetails.Update(employee);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Employee record updated successfully!";
                return RedirectToPage("/EmployeeReview");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating record: {ex.Message}";
                return RedirectToPage("/EmployeeReview");
            }
        }
    }
}
