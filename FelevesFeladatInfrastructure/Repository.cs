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
        //Create
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
        //Update
        public void EmployeeUpdate(Employee emp)
        {
            var empIdUpd = ctx.Employees.FirstOrDefault(e => e.Id == emp.Id);
            ctx.SaveChanges();
        }
        public void DepartmentUpdate(Department dep)
        {
            var depIdUpd = ctx.DepartmentsDb.FirstOrDefault(d => d.DepartmentCode == dep.DepartmentCode);
            depIdUpd.Name = dep.Name;
            depIdUpd.HeadOfDepartment = dep.HeadOfDepartment;
            ctx.SaveChanges();
        }
        public void ManagerUpdate(Manager man)
        {
            var manIdUpd = ctx.Managers.FirstOrDefault(m => m.ManagerId == man.ManagerId);
            manIdUpd.Name = man.Name;
            manIdUpd.BirthYear = man.BirthYear;
            manIdUpd.StartOfEmployment = man.StartOfEmployment;
            manIdUpd.HasMBA = man.HasMBA;
            ctx.SaveChanges();
        }
        //Delete
        public void EmployeeDeleteById(string id)
        {
            var empIdDel = ctx.Employees.FirstOrDefault(e => e.Id == id);
            ctx.Employees.Remove(empIdDel);
            ctx.SaveChanges();
        }
        public void DepartmentDeleteById(string id)
        {
            var depIdDel = ctx.DepartmentsDb.FirstOrDefault(d => d.DepartmentCode == id);
            ctx.DepartmentsDb.Remove(depIdDel);
            ctx.SaveChanges();
        }
        public void ManagerDeleteById(string id)
        {
            var manIdDel = ctx.Managers.FirstOrDefault(m => m.ManagerId == id);
            ctx.Managers.Remove(manIdDel);
            ctx.SaveChanges();
        }
        //Hozzáadás adatbázishoz
        public void AddEmployee(Employee emp)
        {
            var existingManager = ctx.Managers.Find(emp.Id);
            if (existingManager == null)
            {
                ctx.Employees.Add(emp);
            }
            else
            {
                ctx.Entry(existingManager).CurrentValues.SetValues(emp);
            }
            ctx.SaveChanges();
        }
        public void AddDepartment(Department dep)
        {
            var existingManager = ctx.Managers.Find(dep.DepartmentCode);
            if (existingManager == null)
            {
                ctx.DepartmentsDb.Add(dep);
            }
            else
            {
                ctx.Entry(existingManager).CurrentValues.SetValues(dep);
            }
            ctx.SaveChanges();
        }
        public void AddManager(Manager manager)
        {
            var existingManager = ctx.Managers.Find(manager.ManagerId);
            if (existingManager == null)
            {
                ctx.Managers.Add(manager);
            }
            else
            {
                ctx.Entry(existingManager).CurrentValues.SetValues(manager);
            }
            ctx.SaveChanges();
        }


    }
}
