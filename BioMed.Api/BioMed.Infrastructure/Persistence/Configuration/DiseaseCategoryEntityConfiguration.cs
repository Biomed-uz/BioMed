using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioMed.Infrastructure.Persistence.Configuration
{
    public class DiseaseCategoryEntityConfiguration : IEntityTypeConfiguration<DiseaseCategory>
    {
        public void Configure(EntityTypeBuilder<DiseaseCategory> builder)
        {
            builder.ToTable(nameof(DiseaseCategory));
            builder.HasKey(dc => dc.Id);

            builder.Property(dc => dc.Name)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.HasMany(d => d.Diseases)
                .WithOne(dc => dc.DiseaseCategory)
                .HasForeignKey(dc => dc.DiseaseCategoryId)
                .IsRequired(false);
        }
    }
}
