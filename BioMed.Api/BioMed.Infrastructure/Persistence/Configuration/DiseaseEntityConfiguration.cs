using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioMed.Infrastructure.Persistence.Configuration
{
    public class DiseaseEntityConfiguration : IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            builder.ToTable(nameof(Disease));
            builder.HasKey(di => di.Id);

            builder.Property(di => di.Name)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.HasOne(di => di.DiseaseCategory)
                .WithMany(dc => dc.Diseases)
                .HasForeignKey(di => di.DiseaseCategoryId)
                .IsRequired(false);

            builder.HasMany(t => t.Treatments)
                .WithOne(d => d.Disease)
                .HasForeignKey(d => d.DiseaseId)
                .IsRequired(false);
        }
    }
}
