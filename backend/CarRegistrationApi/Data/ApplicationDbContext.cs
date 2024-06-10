using Microsoft.EntityFrameworkCore;
using CarRegistrationApi.Models;

namespace CarRegistrationApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<RegistrationModel> Registrations { get; set; }
    }
}
