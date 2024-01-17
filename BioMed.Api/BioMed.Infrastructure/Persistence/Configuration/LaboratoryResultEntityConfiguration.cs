using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioMed.Infrastructure.Persistence.Configuration
{
    public class LaboratoryResultEntityConfiguration : IEntityTypeConfiguration<LaboratoryResult>
    {
        public void Configure(EntityTypeBuilder<LaboratoryResult> builder)
        {
            builder.ToTable(nameof(LaboratoryResult));
            builder.HasKey(lr => lr.Id);

            builder.Property(lr => lr.Result)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(lr => lr.Date)
                .HasColumnType(nameof(DateTime))
                .IsRequired();

            builder.HasOne(lr => lr.AnalysisType)
                .WithMany(a => a.LabResults)
                .HasForeignKey(lr => lr.AnalysisTypeId);

            builder.HasMany(t => t.Treatments)
                .WithOne(lr => lr.LaboratoryResult)
                .HasForeignKey(lr => lr.LaboratoryResultId);
        }
    }
}
