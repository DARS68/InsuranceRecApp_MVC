using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pojisteni_FULL.Models;

namespace pojisteni_FULL.Data.Configurations
{
	public class InsuredPersonConfiguration : IEntityTypeConfiguration<InsuredPerson>
	{
		public void Configure(EntityTypeBuilder<InsuredPerson> builder)
		{
			builder.Property(p => p.InsuredPersonID).HasComment("InsuredPersonID");
			builder.Property(p => p.FirstName).HasMaxLength(100).HasComment("FirstName");
			builder.Property(p => p.LastName).HasMaxLength(100).HasComment("LastName");
			builder.Property(p => p.Email).HasMaxLength(200).HasComment("Email");
			builder.Property(p => p.PhoneNumber).HasComment("PhoneNumber");
			builder.Property(p => p.StreetAndNumber).HasMaxLength(500).HasComment("StreetAndNumber");
			builder.Property(p => p.City).HasMaxLength(100).HasComment("City");
			builder.Property(p => p.ZipCode).HasMaxLength(20).HasComment("ZipCode");
		}
	}
}
