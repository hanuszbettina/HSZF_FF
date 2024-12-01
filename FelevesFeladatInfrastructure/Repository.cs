using Feleves_Feladat.Models;
using FelevesFeladatDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FelevesFeladatInfrastructure
{
    
    public class Repository:IRepository
    {
        private readonly EmployeeDbContext ctx;
        public Repository(EmployeeDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void CreateEmployee(Employee emp)
        {
            ctx.Employees.Add(emp);
            ctx.SaveChanges();
        }
        public void CreateDepartment(Department dep)
        {
            ctx.DepartmentsDb.Add(dep);
            ctx.SaveChanges();
        }
        public void CreateManager(Manager man)
        {
            ctx.Managers.Add(man);
            ctx.SaveChanges();
        }
        //Read
        public IEnumerable<Employee> ReadAllEmployee()
        {
            return ctx.Employees;
        }
        public IEnumerable<Department> ReadAllDepartment()
        {
            return ctx.DepartmentsDb;
        }
        public IEnumerable<Manager> ReadAllManager()
        {
            return ctx.Managers.ToList();
        }



    }
}
