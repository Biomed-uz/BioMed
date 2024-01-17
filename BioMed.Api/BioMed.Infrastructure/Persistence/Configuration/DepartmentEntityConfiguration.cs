using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioMed.Infrastructure.Persistence.Configuration
{
    public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(nameof(Department));
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(s => s.Spesializations)
                .WithOne(d => d.Department)
                .HasForeignKey(d => d.DepartmentId);
        }
    }
}
