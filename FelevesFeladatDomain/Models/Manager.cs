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
    public class Manager
    {
        public string? Name { get; set; }
        [Key]
        public string? ManagerId { get; set; }
        public int BirthYear { get; set; }
        public DateTime StartOfEmployment { get; set; } //vagy string (2024-11-09)
        public bool HasMBA { get; set; }
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