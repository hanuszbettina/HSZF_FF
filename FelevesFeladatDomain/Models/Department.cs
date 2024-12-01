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
    [ToExport("Department")]
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public Department(string? name, string? departmentCode, string? headOfDepartment)
        {
            Name = name;
            DepartmentCode = departmentCode;
            HeadOfDepartment = headOfDepartment;
        }
        [StringLength(100)]
        public string? Name { get; set; }
        [Key]
        [Required]
        public string? DepartmentCode { get; set; }
        [StringLength(100)]
        public string? HeadOfDepartment { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual Manager? Managercon { get; set; }


        public override string ToString()
        {
            return $"Név: {Name}\nOsztály kód: {DepartmentCode}\nVezető: {HeadOfDepartment}";
        }
    }
}
