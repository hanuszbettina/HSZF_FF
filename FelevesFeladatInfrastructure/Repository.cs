using Feleves_Feladat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FelevesFeladatInfrastructure.Repository;

namespace FelevesFeladatInfrastructure
{
    
    public class Repository
    {
        private readonly EmployeeDbContext _context;


        public Repository(EmployeeDbContext ctx)
        {
            this._context = ctx;
        }

        
    }
}
