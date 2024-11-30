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
    public class Department
    {
        //public Department()
        //{
        //}

        //public Department(string? name, string? departmentCode, string? headOfDepartment)
        //{
        //    Name = name;
        //    DepartmentCode = departmentCode;
        //    HeadOfDepartment = headOfDepartment;
        //}
        [StringLength(100)]
        public string? Name { get; set; }
        [Key]
        [Required]
        public string? DepartmentCode { get; set; }
        [StringLength(100)]
        public string? HeadOfDepartment { get; set; }

        public virtual Employee? Employeecon { get; set; }
        public virtual Manager? Managercon { get; set; }


        public override string ToString()
        {
            return $"Név: {Name}\nOsztály kód: {DepartmentCode}\nVezető: {HeadOfDepartment}";
        }
    }
}
