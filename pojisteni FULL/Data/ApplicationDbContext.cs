using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pojisteni_FULL.Data.Configurations;
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
        public DbSet<pojisteni_FULL.Models.Insurance> Insurance { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseLazyLoadingProxies();

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InsuranceConfiguration());
            modelBuilder.ApplyConfiguration(new InsuredPersonConfiguration());
			
            base.OnModelCreating(modelBuilder);
		}
    }
}