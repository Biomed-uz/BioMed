using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioMed.Infrastructure.Persistence.Configuration
{
    public class DoctorEntityConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable(nameof(Doctor));

            builder.HasKey(doc => doc.Id);

            builder.Property(doc => doc.FullName)
                .HasMaxLength(500)
                .IsRequired(false);
            builder.Property(doc => doc.PhoneNumber)
                .HasMaxLength(50);
            builder.Property(doc => doc.Email)
                .HasMaxLength(255);
            builder.Property(doc => doc.PricePerVisit)
                .HasColumnType("Money");

            builder.HasOne(doc => doc.Spesialization)
                .WithMany(sp => sp.Doctors)
                .HasForeignKey(doc => doc.SpesializationId)
                .IsRequired(false);

            builder.HasMany(v => v.Visits)
                .WithOne(doc => doc.Doctor)
                .HasForeignKey(v => v.DoctorId)
                .IsRequired(false);
        }
    }
}
