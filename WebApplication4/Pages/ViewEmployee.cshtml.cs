using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRecord.Data;
using EmployeeRecord.Models;

namespace WebApplication4.Pages
{
    public class ViewEmployeeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ViewEmployeeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PersonalDetails? Employee { get; set; }

        public async Task OnGetAsync(int id)
        {
            Employee = _context.PersonalDetails.FirstOrDefault(e => e.Id == id);
        }
    }
}
