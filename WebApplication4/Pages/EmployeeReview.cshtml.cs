using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRecord.Data;
using EmployeeRecord.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Pages
{
    public class EmployeeReviewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EmployeeReviewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<PersonalDetails> EmployeeRecords { get; set; } = new();
        public string? SuccessMessage { get; set; }

        public async Task OnGetAsync()
        {
            EmployeeRecords = _context.PersonalDetails.ToList();
            SuccessMessage = TempData["SuccessMessage"] as string;
        }

        public async Task<IActionResult> OnPostAsync(int employeeId)
        {
            var employee = await _context.PersonalDetails.FindAsync(employeeId);
            if (employee != null)
            {
                _context.PersonalDetails.Remove(employee);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Employee record deleted successfully!";
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostReseedAsync()
        {
            try
            {
                // Get all records ordered by ID
                var records = await _context.PersonalDetails.OrderBy(e => e.Id).ToListAsync();

                if (records.Any())
                {
                    // Delete all records
                    _context.PersonalDetails.RemoveRange(records);
                    await _context.SaveChangesAsync();

                    // Re-insert records with new IDs (identity will auto-increment)
                    foreach (var record in records)
                    {
                        record.Id = 0; // Reset ID to let the database assign new ones
                    }

                    _context.PersonalDetails.AddRange(records);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Employee record IDs have been reseeded successfully!";
                }
                else
                {
                    TempData["SuccessMessage"] = "No records to reseed.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error reseeding IDs: {ex.Message}";
            }

            return RedirectToPage();
        }
    }
}
