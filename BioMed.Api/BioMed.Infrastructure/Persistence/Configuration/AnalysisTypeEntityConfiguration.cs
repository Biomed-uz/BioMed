using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioMed.Infrastructure.Persistence.Configuration
{
    public class AnalysisTypeEntityConfiguration : IEntityTypeConfiguration<AnalysisType>
    {
        public void Configure(EntityTypeBuilder<AnalysisType> builder)
        {
            builder.ToTable(nameof(AnalysisType));
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(l => l.LabResults)
                .WithOne(a => a.AnalysisType)
                .HasForeignKey(a => a.AnalysisTypeId);
        }
    }
}
