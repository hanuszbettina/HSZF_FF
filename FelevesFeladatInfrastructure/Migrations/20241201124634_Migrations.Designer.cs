﻿// <auto-generated />
using System;
using FelevesFeladatInfrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FelevesFeladatInfrastructure.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20241201124634_Migrations")]
    partial class Migrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DepartmentEmployee", b =>
                {
                    b.Property<string>("DepartmentsDepartmentCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DepartmentsDepartmentCode", "EmployeesId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("DepartmentEmployee");
                });

            modelBuilder.Entity("Feleves_Feladat.Models.Department", b =>
                {
                    b.Property<string>("DepartmentCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HeadOfDepartment")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DepartmentCode");

                    b.HasIndex("Name");

                    b.ToTable("DepartmentsDb");
                });

            modelBuilder.Entity("Feleves_Feladat.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("BirthYear")
                        .HasColumnType("int");

                    b.Property<int>("Commission")
                        .HasColumnType("int");

                    b.Property<int>("CompletedProjects")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Job")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Level")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Retired")
                        .HasColumnType("bit");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EmployeesDb");
                });

            modelBuilder.Entity("Feleves_Feladat.Models.Manager", b =>
                {
                    b.Property<string>("ManagerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BirthYear")
                        .HasColumnType("int");

                    b.Property<bool>("HasMBA")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartOfEmployment")
                        .HasColumnType("datetime2");

                    b.HasKey("ManagerId");

                    b.ToTable("ManagersDb");
                });

            modelBuilder.Entity("DepartmentEmployee", b =>
                {
                    b.HasOne("Feleves_Feladat.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsDepartmentCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Feleves_Feladat.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Feleves_Feladat.Models.Department", b =>
                {
                    b.HasOne("Feleves_Feladat.Models.Manager", "Managercon")
                        .WithMany("Departments")
                        .HasForeignKey("Name");

                    b.Navigation("Managercon");
                });

            modelBuilder.Entity("Feleves_Feladat.Models.Manager", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
