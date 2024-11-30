using FelevesFeladatDomain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Feleves_Feladat.Models
{
    [ToExport("Employee")]
    public class Employee
    {
        //public Employee(string id)
        //{
        //    Id = id;
        //    Departments = new HashSet<Department>();
        //}

        //public Employee(string id, string? name, int birthYear, int startYear, int completedProjects, bool active, bool retired, string? email, string? phone, string? job, string? level, int salary, int commission)
        //{
        //    Id = id;
        //    Name = name;
        //    BirthYear = birthYear;
        //    StartYear = startYear;
        //    CompletedProjects = completedProjects;
        //    Active = active;
        //    Retired = retired;
        //    Email = email;
        //    Phone = phone;
        //    Job = job;
        //    Level = level;
        //    Salary = salary;
        //    Commission = commission;
        //    Departments = new HashSet<Department>();
        //}

        [Key]
        [Required]
        public string Id { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        public int BirthYear { get; set; }
        public int StartYear { get; set; }
        public int CompletedProjects { get; set; }
        public bool Active { get; set; }
        public bool Retired { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(20)]
        public string? Phone { get; set; }
        [StringLength(50)]
        public string? Job { get; set; }
        [StringLength(50)]
        public string? Level { get; set; }
        public int Salary { get; set; }
        public int Commission { get; set; } //juttatás eur to huf
        public virtual ICollection<Department> Departments { get; set; }
        
        public override string ToString()
        {
            return $"Név: {Name}\nSzületési év: {BirthYear}\nKezdés éve: {StartYear}\nTeljesített projektek: {CompletedProjects}\nAktív: {Active}\nNyugdíjas: {Retired}\nEmail: {Email}\nMunka: {Job}\nSzint: {Level}\nFizetés: {Salary}\nJuttatás: {Commission} HUF\nRészlegek: {Departments.ToString}";
        }

    }
}
