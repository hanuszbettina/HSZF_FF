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
        public void EmployeeUpdate(string id)
        {
            var empIdUpd = ctx.Employees.FirstOrDefault(e => e.Id == id);
            ctx.SaveChanges();
        }
        public void DepartmentUpdate(string id)
        {
            var depIdUpd = ctx.DepartmentsDb.FirstOrDefault(d => d.DepartmentCode == id);
            ctx.SaveChanges();
        }
        public void ManagerUpdate(Manager man)
        {
            //var manIdUpd = ctx.Managers.FirstOrDefault(m => m.ManagerId == id);
            ctx.Managers.Update(man);
            ctx.SaveChanges();
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
