﻿// <auto-generated />
using System;
using ITISchoolConsoleApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITISchoolConsoleApp.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20230302100059_IsEmployeeDisc")]
    partial class IsEmployeeDisc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITISchoolConsoleApp.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmployee")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("People");

                    b.HasDiscriminator<bool>("IsEmployee");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ITISchoolConsoleApp.Student", b =>
                {
                    b.HasBaseType("ITISchoolConsoleApp.Person");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue(false);
                });

            modelBuilder.Entity("ITISchoolConsoleApp.Teacher", b =>
                {
                    b.HasBaseType("ITISchoolConsoleApp.Person");

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasDiscriminator().HasValue(true);
                });
#pragma warning restore 612, 618
        }
    }
}