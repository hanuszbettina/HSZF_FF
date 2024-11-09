using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Feleves_Feladat.Models
{
    public class Employee
    {
        public string? Name { get; set; }
        public int BirthYear { get; set; }
        public int StartYear { get; set; }
        public int CompletedProjects { get; set; }
        public bool Active { get; set; }
        public bool Retired { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Job { get; set; }
        public string? Level { get; set; }
        public int Salary { get; set; }
        public int Commission { get; set; }
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
        public override string ToString()
        {
            return $"Név: {Name}\nSzületési év: {BirthYear}\nKezdés éve: {StartYear}\nTeljesített projektek: {CompletedProjects}\nAktív: {Active}\nNyugdíjas: {Retired}\nEmail: {Email}\nMunka: {Job}\nSzint: {Level}\nFizetés: {Salary}\nBizottság: {Departments.ToString}";
        }

    }
}
