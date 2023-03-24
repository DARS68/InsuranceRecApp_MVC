using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pojisteni_FULL.Models;
using System.ComponentModel.DataAnnotations;

namespace pojisteni_FULL.Data.Configurations
{
	public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
	{
		public void Configure(EntityTypeBuilder<Insurance> builder)
		{
			builder.Property(p => p.InsuranceID).HasComment("InsuranceID");
			builder.Property(p => p.InsuranceName).HasMaxLength(250).HasComment("InsuranceName");
			builder.Property(p => p.InsuranceDescription).HasMaxLength(2000).HasComment("InsuranceDescription");
			builder.Property(p => p.InsuranceAmount).HasComment("InsuranceAmount");
			builder.Property(p => p.SubjectOfInsurance).HasMaxLength(1000).HasComment("SubjectOfInsurance");
			builder.Property(p => p.ValidFrom).HasComment("ValidFrom");
			builder.Property(p => p.ValidTo).HasComment("ValidTo");
			builder.Property(p => p.InsuredPersonId).HasComment("InsuredPersonId");

			builder.HasOne(t => t.InsuredPerson)
				   .WithMany(o => o.Insurances)
				   .HasForeignKey(t => t.InsuredPersonId)
				   .HasConstraintName("FK_InsuredPerson_Insurance");
		}
	}
}
