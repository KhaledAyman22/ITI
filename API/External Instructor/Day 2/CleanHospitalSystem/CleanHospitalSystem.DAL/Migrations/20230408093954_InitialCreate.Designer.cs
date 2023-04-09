﻿// <auto-generated />
using CleanHospitalSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanHospitalSystem.DAL.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20230408093954_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CleanHospitalSystem.DAL.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerformanceRate")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jessie",
                            PerformanceRate = 65,
                            Salary = 27064m,
                            Specialization = "Hematology"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Judy",
                            PerformanceRate = 32,
                            Salary = 18711m,
                            Specialization = "Neurology"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Naomi",
                            PerformanceRate = 27,
                            Salary = 32145m,
                            Specialization = "Pediatrics"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Joann",
                            PerformanceRate = 72,
                            Salary = 9232m,
                            Specialization = "Hematology"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Judy",
                            PerformanceRate = 19,
                            Salary = 48498m,
                            Specialization = "Dermatology"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Alyssa",
                            PerformanceRate = 79,
                            Salary = 16586m,
                            Specialization = "Gastroenterology"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Mable",
                            PerformanceRate = 5,
                            Salary = 33706m,
                            Specialization = "Infectious Disease"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Paula",
                            PerformanceRate = 0,
                            Salary = 19094m,
                            Specialization = "Urology"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Rafael",
                            PerformanceRate = 97,
                            Salary = 12266m,
                            Specialization = "Pediatrics"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Sara",
                            PerformanceRate = 82,
                            Salary = 45041m,
                            Specialization = "Pediatrics"
                        });
                });

            modelBuilder.Entity("CleanHospitalSystem.DAL.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Issues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Diabetes"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hypertension"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Asthma"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Depression"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Arthritis"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Allergy"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Flu"
                        });
                });

            modelBuilder.Entity("CleanHospitalSystem.DAL.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DoctorId = 5,
                            Name = "Dana"
                        },
                        new
                        {
                            Id = 2,
                            DoctorId = 7,
                            Name = "Isaac"
                        },
                        new
                        {
                            Id = 3,
                            DoctorId = 9,
                            Name = "Damon"
                        },
                        new
                        {
                            Id = 4,
                            DoctorId = 8,
                            Name = "Miriam"
                        },
                        new
                        {
                            Id = 5,
                            DoctorId = 7,
                            Name = "Terence"
                        },
                        new
                        {
                            Id = 6,
                            DoctorId = 1,
                            Name = "Roosevelt"
                        },
                        new
                        {
                            Id = 7,
                            DoctorId = 9,
                            Name = "Eduardo"
                        },
                        new
                        {
                            Id = 8,
                            DoctorId = 8,
                            Name = "Wilbert"
                        },
                        new
                        {
                            Id = 9,
                            DoctorId = 5,
                            Name = "Tasha"
                        },
                        new
                        {
                            Id = 10,
                            DoctorId = 1,
                            Name = "Max"
                        },
                        new
                        {
                            Id = 11,
                            DoctorId = 2,
                            Name = "Bridget"
                        },
                        new
                        {
                            Id = 12,
                            DoctorId = 8,
                            Name = "Juan"
                        },
                        new
                        {
                            Id = 13,
                            DoctorId = 10,
                            Name = "Krystal"
                        },
                        new
                        {
                            Id = 14,
                            DoctorId = 10,
                            Name = "Erma"
                        },
                        new
                        {
                            Id = 15,
                            DoctorId = 6,
                            Name = "Orlando"
                        },
                        new
                        {
                            Id = 16,
                            DoctorId = 5,
                            Name = "Marvin"
                        },
                        new
                        {
                            Id = 17,
                            DoctorId = 4,
                            Name = "Lamar"
                        },
                        new
                        {
                            Id = 18,
                            DoctorId = 7,
                            Name = "Joe"
                        },
                        new
                        {
                            Id = 19,
                            DoctorId = 8,
                            Name = "Wendell"
                        },
                        new
                        {
                            Id = 20,
                            DoctorId = 4,
                            Name = "Sandra"
                        },
                        new
                        {
                            Id = 21,
                            DoctorId = 6,
                            Name = "Stephanie"
                        },
                        new
                        {
                            Id = 22,
                            DoctorId = 7,
                            Name = "Ervin"
                        },
                        new
                        {
                            Id = 23,
                            DoctorId = 4,
                            Name = "Beth"
                        },
                        new
                        {
                            Id = 24,
                            DoctorId = 7,
                            Name = "Gretchen"
                        },
                        new
                        {
                            Id = 25,
                            DoctorId = 2,
                            Name = "Gwendolyn"
                        },
                        new
                        {
                            Id = 26,
                            DoctorId = 7,
                            Name = "Jerry"
                        },
                        new
                        {
                            Id = 27,
                            DoctorId = 6,
                            Name = "Mitchell"
                        },
                        new
                        {
                            Id = 28,
                            DoctorId = 8,
                            Name = "Maggie"
                        },
                        new
                        {
                            Id = 29,
                            DoctorId = 3,
                            Name = "Sandy"
                        },
                        new
                        {
                            Id = 30,
                            DoctorId = 2,
                            Name = "Lloyd"
                        });
                });

            modelBuilder.Entity("IssuePatient", b =>
                {
                    b.Property<int>("IssuesId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsId")
                        .HasColumnType("int");

                    b.HasKey("IssuesId", "PatientsId");

                    b.HasIndex("PatientsId");

                    b.ToTable("IssuePatient");
                });

            modelBuilder.Entity("CleanHospitalSystem.DAL.Patient", b =>
                {
                    b.HasOne("CleanHospitalSystem.DAL.Doctor", "Doctor")
                        .WithMany("Patinets")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("IssuePatient", b =>
                {
                    b.HasOne("CleanHospitalSystem.DAL.Issue", null)
                        .WithMany()
                        .HasForeignKey("IssuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanHospitalSystem.DAL.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanHospitalSystem.DAL.Doctor", b =>
                {
                    b.Navigation("Patinets");
                });
#pragma warning restore 612, 618
        }
    }
}
