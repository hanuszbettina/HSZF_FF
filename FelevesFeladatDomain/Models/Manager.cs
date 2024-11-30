using FelevesFeladatDomain.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_Feladat.Models
{
    [ToExport("Manager")]
    public class Manager
    {
        //public Manager()
        //{
        //    Departments = new HashSet<Department>();
        //}

        //public Manager(string? name, string? managerId, int birthYear, DateTime startOfEmployment, bool hasMBA)
        //{
        //    Name = name;
        //    ManagerId = managerId;
        //    BirthYear = birthYear;
        //    StartOfEmployment = startOfEmployment;
        //    HasMBA = hasMBA;
        //    Departments = new HashSet<Department>();
        //}
        [StringLength(100)]
        public string? Name { get; set; }
        [Key]
        [Required]
        public string? ManagerId { get; set; }
        public int BirthYear { get; set; }
        public DateTime StartOfEmployment { get; set; } //vagy string (2024-11-09)
        public bool HasMBA { get; set; }
        public virtual ICollection<Department> Departments { get; set; } 
        public override string ToString()
        {
            if (HasMBA)
            {
                return $"Név: {Name}\nAzonosító: {ManagerId}\nSzületési év: {BirthYear}\nKezdés éve: {StartOfEmployment}\nMBA: Van";
            }
            else
            {
                return $"Név: {Name}\nAzonosító: {ManagerId}\nSzületési év: {BirthYear}\nKezdés éve: {StartOfEmployment}\nMBA: Nincs";
            }
        }
    }
}