using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BioMed.Infrastructure.Persistence
{
    public class BioMedDbContext : DbContext
    {
        public virtual DbSet<Spesialization> Spesializations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<DiseaseCategory> DiseaseCategories { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<LaboratoryResult> LaboratoryResults { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<AnalysisType> AnalysisTypes { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }

        public BioMedDbContext(DbContextOptions<BioMedDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
