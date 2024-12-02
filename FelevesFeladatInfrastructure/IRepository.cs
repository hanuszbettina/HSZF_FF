using Feleves_Feladat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesFeladatInfrastructure
{
    public interface IRepository
    {
        void CreateEmployee(Employee emp);
        void CreateDepartment(Department dep);
        void CreateManager(Manager man);
        IEnumerable<Employee> ReadAllEmployee();
        IEnumerable<Department> ReadAllDepartment();
        IEnumerable<Manager> ReadAllManager();
        void EmployeeUpdate(string id, Employee emp );
        void DepartmentUpdate(string id, Department dep);
        void ManagerUpdate(string id, Manager man);
        void EmployeeDeleteById(string id);
        void DepartmentDeleteById(string id);
        void ManagerDeleteById(string id);
        void AddEmployee(Employee emp);
        void AddDepartment(Department dep);
        void AddManager(Manager manager);
    }
}
