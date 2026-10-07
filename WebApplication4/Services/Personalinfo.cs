using EmployeeRecord.Data;
using EmployeeRecord.Models;

namespace EmployeeRecord.Services
{
    public class Personalinfo
    {
        private readonly ApplicationDbContext _context;

        public Personalinfo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonalDetails>> GetAllPersonalDetailsAsync()
        {
            return _context.PersonalDetails.ToList();
        }

        public async Task<PersonalDetails?> GetPersonalDetailsByIdAsync(int id)
        {
            return _context.PersonalDetails.FirstOrDefault(p => p.Id == id);
        }

        public async Task AddPersonalDetailsAsync(PersonalDetails personalDetails)
        {
            _context.PersonalDetails.Add(personalDetails);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersonalDetailsAsync(PersonalDetails personalDetails)
        {
            _context.PersonalDetails.Update(personalDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonalDetailsAsync(int id)
        {
            var personalDetails = await GetPersonalDetailsByIdAsync(id);
            if (personalDetails != null)
            {
                _context.PersonalDetails.Remove(personalDetails);
                await _context.SaveChangesAsync();
            }
        }
    }
}
