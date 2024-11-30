﻿using Feleves_Feladat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesFeladatInfrastructure
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> EmployeesDb { get; set; }
        public DbSet<Department> DepartmentsDb { get; set; }
        public DbSet<Manager> ManagersDb { get; set; }
        public EmployeeDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=EmployeeDb;Integrated Security=True;MultipleActiveResultSets=true"; ;
            optionsBuilder.UseSqlServer(connStr);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(m => m.Departments)
                .WithOne(r => r.Employeecon);
            modelBuilder.Entity<Manager>()
                .HasMany(m => m.Departments)
                .WithOne(r => r.Managercon)
                .HasForeignKey(r => r.Name);
        }
    }
}