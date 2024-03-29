﻿// <auto-generated />
using System;
using BioMed.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BioMed.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(BioMedDbContext))]
    [Migration("20240119164938_Initial_Create")]
    partial class Initial_Create
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BioMed.Domain.Entities.AnalysisType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("AnalysisType", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiseaseCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseCategoryId");

                    b.ToTable("Disease", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.DiseaseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("DiseaseCategory", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PricePerVisit")
                        .HasColumnType("Money");

                    b.Property<int>("SpesializationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpesializationId");

                    b.ToTable("Doctor", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.LaboratoryResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnalysisTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("AnalysisTypeId");

                    b.ToTable("LaboratoryResult", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("Money");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Spesialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Spesialization", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<int>("LaboratoryResultId")
                        .HasColumnType("int");

                    b.Property<string>("Prescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.HasIndex("LaboratoryResultId");

                    b.HasIndex("VisitId");

                    b.ToTable("Treatment", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Prescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("Money");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visit", (string)null);
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Disease", b =>
                {
                    b.HasOne("BioMed.Domain.Entities.DiseaseCategory", "DiseaseCategory")
                        .WithMany("Diseases")
                        .HasForeignKey("DiseaseCategoryId");

                    b.Navigation("DiseaseCategory");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("BioMed.Domain.Entities.Spesialization", "Spesialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpesializationId");

                    b.Navigation("Spesialization");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.LaboratoryResult", b =>
                {
                    b.HasOne("BioMed.Domain.Entities.AnalysisType", "AnalysisType")
                        .WithMany("LabResults")
                        .HasForeignKey("AnalysisTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnalysisType");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Payment", b =>
                {
                    b.HasOne("BioMed.Domain.Entities.Visit", "Visit")
                        .WithMany("Payments")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Spesialization", b =>
                {
                    b.HasOne("BioMed.Domain.Entities.Department", "Department")
                        .WithMany("Spesializations")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Treatment", b =>
                {
                    b.HasOne("BioMed.Domain.Entities.Disease", "Disease")
                        .WithMany("Treatments")
                        .HasForeignKey("DiseaseId");

                    b.HasOne("BioMed.Domain.Entities.LaboratoryResult", "LaboratoryResult")
                        .WithMany("Treatments")
                        .HasForeignKey("LaboratoryResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioMed.Domain.Entities.Visit", "Visit")
                        .WithMany("Treatments")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");

                    b.Navigation("LaboratoryResult");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Visit", b =>
                {
                    b.HasOne("BioMed.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Visits")
                        .HasForeignKey("DoctorId");

                    b.HasOne("BioMed.Domain.Entities.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.AnalysisType", b =>
                {
                    b.Navigation("LabResults");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Department", b =>
                {
                    b.Navigation("Spesializations");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Disease", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.DiseaseCategory", b =>
                {
                    b.Navigation("Diseases");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.LaboratoryResult", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Spesialization", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("BioMed.Domain.Entities.Visit", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Treatments");
                });
#pragma warning restore 612, 618
        }
    }
}
