using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BioMed.Infrastructure.Persistence.Configuration
{
    public class SpesializationEntityConfiguration : IEntityTypeConfiguration<Spesialization>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Spesialization> builder)
        {
            builder.ToTable(nameof(Spesialization));
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.HasOne(s => s.Department)
                .WithMany(d => d.Spesializations)
                .HasForeignKey(s => s.DepartmentId);

            builder.HasMany(s => s.Doctors)
                .WithOne(d => d.Spesialization)
                .HasForeignKey(d => d.SpesializationId);
        }
    }
}
