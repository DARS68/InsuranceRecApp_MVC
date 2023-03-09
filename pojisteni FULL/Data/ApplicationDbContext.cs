using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pojisteni_FULL.Models;

namespace pojisteni_FULL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<pojisteni_FULL.Models.InsuredPerson> InsuredPerson { get; set; }
    }
}