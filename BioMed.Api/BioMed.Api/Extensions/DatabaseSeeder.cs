using BioMed.Domain.Entities;
using BioMed.Infrastructure.Persistence;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace BioMed.Api.Extensions
{
    public static class DatabaseSeeder
    {
        private static Faker _faker = new Faker();

        public static void SeedDatabase(this IServiceCollection _, IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<BioMedDbContext>>();
            using var context = new BioMedDbContext(options);

            CreateSpesializations(context);
        }

        private static void CreateSpesializations(BioMedDbContext context)
        {
            if (context.Spesializations.Any()) return;
            var spesializations = new List<Spesialization>
            {
                new Spesialization()
                {
                    Name = "Trauma care",
                    DepartmentId = 1
                },
                new Spesialization()
                {
                    Name = "Critical  care",
                    DepartmentId = 1
                },
                new Spesialization()
                {
                    Name = "General medicine",
                    DepartmentId = 2
                },
                new Spesialization()
                {
                    Name = "General surgery",
                    DepartmentId = 2
                },
                new Spesialization()
                {
                    Name = "Medical ICU (MICU)",
                    DepartmentId = 3
                },
                new Spesialization()
                {
                    Name = "Surgical ICU (SICU)",
                    DepartmentId = 3
                },
                new Spesialization()
                {
                    Name = "Cardiovascular ICU (CVICU)",
                    DepartmentId = 3
                },
                new Spesialization()
                {
                    Name = "Clinical pathology",
                    DepartmentId = 4
                },
                new Spesialization()
                {
                    Name = "Hematology",
                    DepartmentId = 4
                },
                new Spesialization()
                {
                    Name = "Microbiology",
                    DepartmentId = 4
                },
                new Spesialization()
                {
                    Name = "Clinical chemistry",
                    DepartmentId = 4
                },
                new Spesialization()
                {
                    Name = "Diagnostic radiology",
                    DepartmentId = 5
                },
                new Spesialization()
                {
                    Name = "Interventional radiology",
                    DepartmentId = 5
                },
                new Spesialization()
                {
                    Name = "Nuclear medicine",
                    DepartmentId = 5
                },
                new Spesialization()
                {
                    Name = "Clinical pharmacy",
                    DepartmentId = 6
                },
                new Spesialization()
                {
                    Name = "Compounding pharmacy",
                    DepartmentId = 6
                },
                new Spesialization()
                {
                    Name = "Oncology pharmacy",
                    DepartmentId = 6
                },
                new Spesialization()
                {
                    Name = "General surgery",
                    DepartmentId = 7
                },
                new Spesialization()
                {
                    Name = "Orthopedic surgery",
                    DepartmentId = 7
                },
                new Spesialization()
                {
                    Name = "Neurosurgery",
                    DepartmentId = 7
                },
                new Spesialization()
                {
                    Name = "Cardiothoracic surgery",
                    DepartmentId = 7
                },
                new Spesialization()
                {
                    Name = "Obstetrics",
                    DepartmentId = 8
                },
                new Spesialization()
                {
                    Name = "Gynecology",
                    DepartmentId = 8
                },
                new Spesialization()
                {
                    Name = "Maternal-fetal medicine",
                    DepartmentId = 8
                },
                new Spesialization()
                {
                    Name = "Neonatology",
                    DepartmentId = 9
                },
                new Spesialization()
                {
                    Name = "Pediatric cardiology",
                    DepartmentId = 9
                },
                new Spesialization()
                {
                    Name = "Pediatric oncology",
                    DepartmentId = 9
                },
                new Spesialization()
                {
                    Name = "Interventional cardiology",
                    DepartmentId = 10
                },
                new Spesialization()
                {
                    Name = "Electrophysiology",
                    DepartmentId = 10
                },
                new Spesialization()
                {
                    Name = "Heart failure",
                    DepartmentId = 10
                },
                new Spesialization()
                {
                    Name = "Neurophysiology",
                    DepartmentId = 11
                },
                new Spesialization()
                {
                    Name = "Neurosurgery",
                    DepartmentId = 11
                },
                new Spesialization()
                {
                    Name = "Stroke care",
                    DepartmentId = 11
                },
                new Spesialization()
                {
                    Name = "Sports medicine",
                    DepartmentId = 12
                },
                new Spesialization()
                {
                    Name = "Joint replacement",
                    DepartmentId = 12
                },
                new Spesialization()
                {
                    Name = "Hepatology",
                    DepartmentId = 13
                },
                new Spesialization()
                {
                    Name = "Endoscopy",
                    DepartmentId = 13
                },
                new Spesialization()
                {
                    Name = "Medical oncology",
                    DepartmentId = 14
                },
                new Spesialization()
                {
                    Name = "Radiation oncology",
                    DepartmentId = 14
                },
                new Spesialization()
                {
                    Name = "Surgical oncology",
                    DepartmentId = 14
                },
                new Spesialization()
                {
                    Name = "Adult psychiatry",
                    DepartmentId = 15
                },
                new Spesialization()
                {
                    Name = "Child and adolescent psychiatry",
                    DepartmentId = 15
                },
                new Spesialization()
                {
                    Name = "Clinical psychology",
                    DepartmentId = 15
                },
                new Spesialization()
                {
                    Name = "Physical therapy",
                    DepartmentId = 16
                },
                new Spesialization()
                {
                    Name = "Occupational therapy",
                    DepartmentId = 16
                },
                new Spesialization()
                {
                    Name = "Speech therapy",
                    DepartmentId = 16
                },
                new Spesialization()
                {
                    Name = "Clinical nutrition",
                    DepartmentId = 17
                },
                new Spesialization()
                {
                    Name = "Dietetics",
                    DepartmentId = 17
                },
                new Spesialization()
                {
                    Name = "Hospital administration",
                    DepartmentId = 18
                },
                new Spesialization()
                {
                    Name = "Health services management",
                    DepartmentId = 18
                },
                new Spesialization()
                {
                    Name = "Infection prevention",
                    DepartmentId = 19
                },
                new Spesialization()
                {
                    Name = "Epidemiology",
                    DepartmentId = 19
                },
                new Spesialization()
                {
                    Name = "Health information technology",
                    DepartmentId = 20
                },
                new Spesialization()
                {
                    Name = "Medical coding",
                    DepartmentId = 20
                },
                new Spesialization()
                {
                    Name = "Biomedical engineering",
                    DepartmentId = 21
                },
                new Spesialization()
                {
                    Name = "Facilities management",
                    DepartmentId = 21
                },
                new Spesialization()
                {
                    Name = "Performance improvement",
                    DepartmentId = 22
                },
                new Spesialization()
                {
                    Name = "Patient safety",
                    DepartmentId = 22
                },
            };

            context.Spesializations.AddRange(spesializations);
            context.SaveChanges();
        }
    }
}
