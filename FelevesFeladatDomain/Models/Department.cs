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
        public string? Name { get; set; }
        public string? DepartmentCode { get; set; }

        public string? HeadOfDepartment { get; set; }

        public override string ToString()
        {
            return $"Név: {Name}\nOsztály kód: {DepartmentCode}\nVezető: {HeadOfDepartment}";
        }
    }
}
