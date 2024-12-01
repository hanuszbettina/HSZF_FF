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

        
        
    }
}
