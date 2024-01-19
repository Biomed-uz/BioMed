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
            CreateDepartments(context);
            CreateDoctors(context);
            CreatePatients(context);
            CreateVisits(context);
            CreatePayments(context);
            CreateAnalysisTypes(context);
            CreateLaboratoryResults(context);
            CreateDiseaseCategories(context);
            CreateDiseases(context);
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

        private static void CreateDepartments(BioMedDbContext context)
        {
            if (context.Departments.Any()) return;
            var departments = new List<Department>
            {
                new Department()
                {
                    Name = "Emergency Department"
                },
                new Department()
                {
                    Name = "Medical Ward"
                },
                new Department()
                {
                    Name = "Intensive Care Unit"
                },
                new Department()
                {
                    Name = "Laboratory"
                },
                new Department()
                {
                    Name = "Radiology"
                },
                new Department()
                {
                    Name = "Pharmacy"
                },
                new Department()
                {
                    Name = "Operating Room"
                },
                new Department()
                {
                    Name = "Obstetrics and Gynecology"
                },
                new Department()
                {
                    Name = "Pediatrics"
                },
                new Department()
                {
                    Name = "Cardiology"
                },
                new Department()
                {
                    Name = "Neurology"
                },
                new Department()
                {
                    Name = "Orthopedics"
                },
                new Department()
                {
                    Name = "Gastroenterology"
                },
                new Department()
                {
                    Name = "Oncology"
                },
                new Department()
                {
                    Name = "Psychiatry"
                },
                new Department()
                {
                    Name = "Rehabilitation"
                },
                new Department()
                {
                    Name = "Nutrition Services"
                },
                new Department()
                {
                    Name = "Administration"
                },
                new Department()
                {
                    Name = "Infection Control"
                },
                new Department()
                {
                    Name = "Health Information Management"
                },
                new Department()
                {
                    Name = "Facilities"
                },
                new Department()
                {
                    Name = "Quality Improvement"
                },
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();
        }

        public static void CreateDoctors(BioMedDbContext context)
        {
            if (context.Doctors.Any()) return;

            var spesializations = context.Spesializations.ToList();
            var doctors = new List<Doctor>();

            foreach (var spesialization in spesializations)
            {
                var spesializationsCount = new Random().Next(2, 4);

                for (int i = 0; i < spesializationsCount; i++)
                {
                    doctors.Add(new Doctor
                    {
                        FullName = _faker.Name.FullName(),
                        PhoneNumber = _faker.Phone.PhoneNumber("+998-(##) ###-##-##"),
                        Email = _faker.Name.FirstName() + "@gmail.com",
                        PricePerVisit = _faker.Random.Decimal(50_000, 1_000_000),
                        SpesializationId = spesialization.Id,
                    });
                }
            }
            context.Doctors.AddRange(doctors);
            context.SaveChanges();
        }

        public static void CreatePatients(BioMedDbContext context)
        {
            if (context.Patients.Any()) return;

            var patients = new List<Patient>();
            var genders = new[] { "Male", "Female" };

            for (int i = 0; i < 1000000; i++)
            {
                patients.Add(new Patient()
                {
                    FirstName = _faker.Name.FirstName(),
                    LastName = _faker.Name.LastName(),
                    MiddleName = _faker.Name.FirstName(),
                    PhoneNumber = _faker.Phone.PhoneNumber("+998-(##) ###-##-##"),
                    RegistrationDate = _faker.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now),
                    Email = _faker.Name.FirstName() + "@gmail.com",
                    Gender = _faker.PickRandom(genders)
                });
            }

            context.Patients.AddRange(patients);
            context.SaveChanges();
        }

        public static void CreateVisits(BioMedDbContext context)
        {
            if (context.Visits.Any()) return;

            var patients = context.Patients.ToList();
            var doctors = context.Doctors.ToList();

            var visits = new List<Visit>();

            foreach (var patient in patients)
            {
                var randomDoctor = _faker.PickRandom(doctors);

                visits.Add(new Visit()
                {
                    VisitDate = _faker.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now),
                    Prescription = _faker.Lorem.Sentence(),
                    TotalPrice = _faker.Random.Decimal(200_000, 2_000_000),
                    DoctorId = randomDoctor.Id,
                    PatientId = patient.Id,
                });
            }

            context.Visits.AddRange(visits);
            context.SaveChanges();
        }

        public static void CreatePayments(BioMedDbContext context)
        {
            if (context.Payments.Any()) return;

            var visits = context.Visits.ToList();

            var payments = new List<Payment>();

            foreach (var visit in visits)
            {
                payments.Add(new Payment()
                {
                    Amount = visit.TotalPrice + (visit.TotalPrice * (decimal)0.025),
                    Date = _faker.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now),
                    VisitId = visit.Id,
                });
            }

            context.Payments.AddRange(payments);
            context.SaveChanges();
        }

        public static void CreateAnalysisTypes(BioMedDbContext context)
        {
            if (context.AnalysisTypes.Any()) return;

            var analysisTypes = new List<AnalysisType>
            {
                new AnalysisType() { Name = "Complete Blood Count (CBC)" },
                new AnalysisType() { Name = "Blood Chemistry Panel" },
                new AnalysisType() { Name = "Blood Type and Rh Factor" },
                new AnalysisType() { Name = "Coagulation Panel (Clotting Factors)" },
                new AnalysisType() { Name = "Lipid Panel (Cholesterol Levels)" },
                new AnalysisType() { Name = "Blood Glucose (Blood Sugar)" },
                new AnalysisType() { Name = "Routine Urinalysis" },
                new AnalysisType() { Name = "Microscopic Examination of Urine" },
                new AnalysisType() { Name = "X-rays" },
                new AnalysisType() { Name = "Computed Tomography (CT) Scan" },
                new AnalysisType() { Name = "Magnetic Resonance Imaging (MRI)" },
                new AnalysisType() { Name = "Ultrasound" },
                new AnalysisType() { Name = "Positron Emission Tomography (PET) Scan" },
                new AnalysisType() { Name = "Mammography" },
                new AnalysisType() { Name = "Electrocardiogram (ECG or EKG)" },
                new AnalysisType() { Name = "Electroencephalogram (EEG)" },
                new AnalysisType() { Name = "Upper Gastrointestinal Endoscopy" },
                new AnalysisType() { Name = "Colonoscopy" },
                new AnalysisType() { Name = "Bronchoscopy" },
                new AnalysisType() { Name = "Biopsy" },
                new AnalysisType() { Name = "Pap Smear" },
                new AnalysisType() { Name = "Genetic Testing" },
                new AnalysisType() { Name = "Allergy Testing" },
                new AnalysisType() { Name = "Thyroid Function Tests" },
                new AnalysisType() { Name = "Hormone Levels (e.g., estrogen, testosterone)" },
                new AnalysisType() { Name = "Clinical pathology" },
                new AnalysisType() { Name = "Hematology" },
                new AnalysisType() { Name = "Microbiology" },
                new AnalysisType() { Name = "Clinical chemistry" },
            };

            context.AnalysisTypes.AddRange(analysisTypes);
            context.SaveChanges();
        }

        public static void CreateLaboratoryResults(BioMedDbContext context)
        {
            if (context.LaboratoryResults.Any()) return;

            var analysisTypes = context.AnalysisTypes.ToList();

            var laboratoryResult = new List<LaboratoryResult>();

            foreach (var analysisType in analysisTypes)
            {
                var labResultCount = _faker.Random.Int(20_000, 40_000);

                for (int i = 0; i < labResultCount; i++)
                {
                    laboratoryResult.Add(new LaboratoryResult()
                    {
                        Result = _faker.Lorem.Sentence(),
                        Date = _faker.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now),
                        AnalysisTypeId = analysisType.Id,
                    });
                }
            }

            context.LaboratoryResults.AddRange(laboratoryResult);
            context.SaveChanges();
        }

        private static void CreateDiseaseCategories(BioMedDbContext context)
        {
            if (context.DiseaseCategories.Any()) return;

            var diseaseCategories = new List<DiseaseCategory>
            {
                new DiseaseCategory() { Name = "Infectious Diseases" },
                new DiseaseCategory() { Name = "Cardiovascular Diseases" },
                new DiseaseCategory() { Name = "Respiratory Diseases" },
                new DiseaseCategory() { Name = "Neurological Disorders" },
                new DiseaseCategory() { Name = "Gastrointestinal Diseases" },
                new DiseaseCategory() { Name = "Endocrine Disorders" },
                new DiseaseCategory() { Name = "Musculoskeletal Disorders" },
                new DiseaseCategory() { Name = "Hematological Disorders" },
                new DiseaseCategory() { Name = "Oncological Disorders" },
                new DiseaseCategory() { Name = "Genetic Disorders" },
                new DiseaseCategory() { Name = "Psychiatric Disorders" },
                new DiseaseCategory() { Name = "Autoimmune Diseases" },
                new DiseaseCategory() { Name = "Renal Diseases" },
                new DiseaseCategory() { Name = "Dermatological Conditions" },
                new DiseaseCategory() { Name = "Reproductive Health Issues" },
                new DiseaseCategory() { Name = "Allergic Conditions" },
                new DiseaseCategory() { Name = "Dental and Oral Health Issues" },
                new DiseaseCategory() { Name = "Vector-Borne Diseases" },
                new DiseaseCategory() { Name = "Rare Diseases" },
                new DiseaseCategory() { Name = "Environmental and Occupational Diseases" },
            };

            context.DiseaseCategories.AddRange(diseaseCategories);
            context.SaveChanges();
        }

        private static void CreateDiseases(BioMedDbContext context)
        {
            if (context.Diseases.Any()) return;

            var diseases = new List<Disease>
            {
                new Disease() { Name = "Influenza", DiseaseCategoryId = 1 },
                new Disease() { Name = "Tuberculosis", DiseaseCategoryId = 1 },
                new Disease() { Name = "HIV/AIDS", DiseaseCategoryId = 1 },
                new Disease() { Name = "Malaria", DiseaseCategoryId = 1 },
                new Disease() { Name = "COVID-19", DiseaseCategoryId = 1 },
                new Disease() { Name = "Coronary Artery Disease", DiseaseCategoryId = 2 },
                new Disease() { Name = "Hypertension", DiseaseCategoryId = 2 },
                new Disease() { Name = "Heart Failure", DiseaseCategoryId = 2 },
                new Disease() { Name = "Stroke", DiseaseCategoryId = 2 },
                new Disease() { Name = "Asthma", DiseaseCategoryId = 3 },
                new Disease() { Name = "Chronic Obstructive Pulmonary Disease (COPD)", DiseaseCategoryId = 3 },
                new Disease() { Name = "Pneumonia", DiseaseCategoryId = 3 },
                new Disease() { Name = "Lung Cancer", DiseaseCategoryId = 3 },
                new Disease() { Name = "Alzheimer's Disease", DiseaseCategoryId = 4 },
                new Disease() { Name = "Parkinson's Disease", DiseaseCategoryId = 4 },
                new Disease() { Name = "Epilepsy", DiseaseCategoryId = 4 },
                new Disease() { Name = "Multiple Sclerosis", DiseaseCategoryId = 4 },
                new Disease() { Name = "Gastroenteritis", DiseaseCategoryId = 5 },
                new Disease() { Name = "Inflammatory Bowel Disease (IBD)", DiseaseCategoryId = 5 },
                new Disease() { Name = "Peptic Ulcer Disease", DiseaseCategoryId = 5 },
                new Disease() { Name = "Liver Cirrhosis", DiseaseCategoryId = 5 },
                new Disease() { Name = "Diabetes Mellitus", DiseaseCategoryId = 6 },
                new Disease() { Name = "Thyroid Disorders", DiseaseCategoryId = 6 },
                new Disease() { Name = "Addison's Disease", DiseaseCategoryId = 6 },
                new Disease() { Name = "Cushing's Syndrome", DiseaseCategoryId = 6 },
                new Disease() { Name = "Osteoarthritis", DiseaseCategoryId = 7 },
                new Disease() { Name = "Rheumatoid Arthritis", DiseaseCategoryId = 7 },
                new Disease() { Name = "Osteoporosis", DiseaseCategoryId = 7 },
                new Disease() { Name = "Muscular Dystrophy", DiseaseCategoryId = 7 },
                new Disease() { Name = "Anemia", DiseaseCategoryId = 8 },
                new Disease() { Name = "Hemophilia", DiseaseCategoryId = 8 },
                new Disease() { Name = "Leukemia", DiseaseCategoryId = 8 },
                new Disease() { Name = "Thrombocytopenia", DiseaseCategoryId = 8 },
                new Disease() { Name = "Breast Cancer", DiseaseCategoryId = 9 },
                new Disease() { Name = "Lung Cancer", DiseaseCategoryId = 9 },
                new Disease() { Name = "Colorectal Cancer", DiseaseCategoryId = 9 },
                new Disease() { Name = "Prostate Cancer", DiseaseCategoryId = 9 },
                new Disease() { Name = "Down Syndrome", DiseaseCategoryId = 10 },
                new Disease() { Name = "Cystic Fibrosis", DiseaseCategoryId = 10 },
                new Disease() { Name = "Huntington's Disease", DiseaseCategoryId = 10 },
                new Disease() { Name = "Sickle Cell Anemia", DiseaseCategoryId = 10 },
                new Disease() { Name = "Depression", DiseaseCategoryId = 11 },
                new Disease() { Name = "Anxiety Disorders", DiseaseCategoryId = 11 },
                new Disease() { Name = "Schizophrenia", DiseaseCategoryId = 11 },
                new Disease() { Name = "Bipolar Disorder", DiseaseCategoryId = 11 },
                new Disease() { Name = "Rheumatoid Arthritis", DiseaseCategoryId = 12 },
                new Disease() { Name = "Lupus", DiseaseCategoryId = 12 },
                new Disease() { Name = "Type 1 Diabetes", DiseaseCategoryId = 12 },
                new Disease() { Name = "Multiple Sclerosis", DiseaseCategoryId = 12 },
                new Disease() { Name = "Chronic Kidney Disease", DiseaseCategoryId = 13 },
                new Disease() { Name = "Nephrotic Syndrome", DiseaseCategoryId = 13 },
                new Disease() { Name = "Renal Failure", DiseaseCategoryId = 13 },
                new Disease() { Name = "Kidney Stones", DiseaseCategoryId = 13 },
                new Disease() { Name = "Psoriasis", DiseaseCategoryId = 14 },
                new Disease() { Name = "Eczema", DiseaseCategoryId = 14 },
                new Disease() { Name = "Acne", DiseaseCategoryId = 14 },
                new Disease() { Name = "Dermatitis", DiseaseCategoryId = 14 },
                new Disease() { Name = "Polycystic Ovary Syndrome (PCOS)", DiseaseCategoryId = 15 },
                new Disease() { Name = "Endometriosis", DiseaseCategoryId = 15 },
                new Disease() { Name = "Infertility", DiseaseCategoryId = 15 },
                new Disease() { Name = "Erectile Dysfunction", DiseaseCategoryId = 15 },
                new Disease() { Name = "Allergic Rhinitis", DiseaseCategoryId = 16 },
                new Disease() { Name = "Asthma", DiseaseCategoryId = 16 },
                new Disease() { Name = "Atopic Dermatitis", DiseaseCategoryId = 16 },
                new Disease() { Name = "Food Allergies", DiseaseCategoryId = 16 },
                new Disease() { Name = "Tooth Decay", DiseaseCategoryId = 17 },
                new Disease() { Name = "Gum Disease", DiseaseCategoryId = 17 },
                new Disease() { Name = "Oral Cancer", DiseaseCategoryId = 17 },
                new Disease() { Name = "Temporomandibular Joint (TMJ) Disorders", DiseaseCategoryId = 17 },
                new Disease() { Name = "Malaria", DiseaseCategoryId = 18 },
                new Disease() { Name = "Zika Virus", DiseaseCategoryId = 18 },
                new Disease() { Name = "Dengue Fever", DiseaseCategoryId = 18 },
                new Disease() { Name = "Lyme Disease", DiseaseCategoryId = 18 },
                new Disease() { Name = "Amyotrophic Lateral Sclerosis (ALS)", DiseaseCategoryId = 19 },
                new Disease() { Name = "Huntington's Disease", DiseaseCategoryId = 19 },
                new Disease() { Name = "Pompe Disease", DiseaseCategoryId = 19 },
                new Disease() { Name = "Fabry Disease", DiseaseCategoryId = 19 },
                new Disease() { Name = "Asbestosis", DiseaseCategoryId = 20 },
                new Disease() { Name = "Silicosis", DiseaseCategoryId = 20 },
                new Disease() { Name = "Lead Poisoning", DiseaseCategoryId = 20 },
                new Disease() { Name = "Black Lung Disease", DiseaseCategoryId = 20 },
            };
            context.Diseases.AddRange(diseases);
            context.SaveChanges();
        }
    }
}
