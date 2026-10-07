using Microsoft.EntityFrameworkCore;
using EmployeeRecord.Models;

namespace EmployeeRecord.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<DemographicInfo> DemographicInfo { get; set; }
        public DbSet<IdDocuments> IdDocuments { get; set; }
    }
}