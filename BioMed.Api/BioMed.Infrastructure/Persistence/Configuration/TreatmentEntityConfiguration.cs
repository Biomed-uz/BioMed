using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioMed.Infrastructure.Persistence.Configuration
{
    public class TreatmentEntityConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.ToTable(nameof(Treatment));
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Prescription)
                .HasMaxLength(500);

            builder.HasOne(t => t.Visit)
                .WithMany(v => v.Treatments)
                .HasForeignKey(t => t.VisitId);

            builder.HasOne(t => t.Disease)
                .WithMany(d => d.Treatments)
                .HasForeignKey(t => t.DiseaseId);

            builder.HasOne(t => t.LaboratoryResult)
                .WithMany(l => l.Treatments)
                .HasForeignKey(t => t.LaboratoryResultId);
        }
    }
}
