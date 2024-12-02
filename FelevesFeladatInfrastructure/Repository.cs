using Feleves_Feladat.Models;
using FelevesFeladatDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
        public void EmployeeUpdate(string id, Employee emp)
        {
            var empUpdate = ctx.Employees.First(t => t.Id == id);
            if (emp != null)
            {
                empUpdate.Id = emp.Id;
                empUpdate.Name = emp.Name;
                empUpdate.BirthYear = emp.BirthYear;
                empUpdate.StartYear=emp.StartYear;
                empUpdate.CompletedProjects= emp.CompletedProjects;
                empUpdate.Active= emp.Active;
                empUpdate.Retired = emp.Retired;
                empUpdate.Email = emp.Email;
                empUpdate.Phone = emp.Phone;
                empUpdate.Job=emp.Job;
                empUpdate.Level=emp.Level;
                empUpdate.Salary=emp.Salary;
                empUpdate.Commission=emp.Commission;
                ctx.SaveChanges();
            }
        }
        public void DepartmentUpdate(string id, Department dep)
        {
            var depUpdate = ctx.DepartmentsDb.First(t => t.DepartmentCode == id);
            if (dep != null)
            {
                depUpdate.Name = dep.Name;
                depUpdate.DepartmentCode = dep.DepartmentCode;
                depUpdate.HeadOfDepartment = dep.HeadOfDepartment;
                ctx.SaveChanges();
            }
        }
        public void ManagerUpdate(string id, Manager man)
        {
            var manUpdate = ctx.Managers.First(t => t.ManagerId == id);
            if (man != null)
            {
                manUpdate.Name=man.Name;
                manUpdate.ManagerId = man.ManagerId;
                manUpdate.BirthYear = man.BirthYear;
                manUpdate.StartOfEmployment = man.StartOfEmployment;
                manUpdate.HasMBA = man.HasMBA;
                ctx.SaveChanges();
            }
        }
        //Delete
        public void EmployeeDeleteById(string id)
        {
            var emp = ctx.Employees.Find(id);
            if (emp != null)
            {
                ctx.Employees.Remove(emp);
                ctx.SaveChanges();
            }
        }
        public void DepartmentDeleteById(string id)
        {
            var dep = ctx.DepartmentsDb.Find(id);
            if (dep != null)
            {
                ctx.DepartmentsDb.Remove(dep);
                ctx.SaveChanges();
            }
        }
        public void ManagerDeleteById(string id)
        {
            var manager = ctx.Managers.Find(id);
            if (manager != null)
            {
                ctx.Managers.Remove(manager);
                ctx.SaveChanges();
            }
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
