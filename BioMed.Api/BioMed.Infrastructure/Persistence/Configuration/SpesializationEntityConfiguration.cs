using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
                .IsRequired();

            builder.HasOne(s => s.Department)
                .WithMany(d => d.Spesializations)
                .HasForeignKey(s => s.DepartmentId);
        }
    }
}
