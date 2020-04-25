using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.Infrastructure.Interfaces;
using Webstore.Models;

namespace Webstore.Infrastructure.Services
{
    public class InMemoryEmployeeService : IEmployeeService
    {
        List<EmployeeViewModel> _employees;
        public InMemoryEmployeeService()
        {
            _employees = new List<EmployeeViewModel>
        {
            new EmployeeViewModel
            {
                ID =1,
                FirstName = "Ivan",
                SurName = "Ivanov",
                Patronymic = "Ivanovich",
                Age = 22,
                Position="Master"
            },
            new EmployeeViewModel
            {
                ID =2,
                FirstName = "Igor",
                SurName = "Petrov",
                Patronymic = "Petrovich",
                Age = 44,
                Position="Slave"
            }
        };
        }
        public void AddNew(EmployeeViewModel model)
        {
            model.ID = _employees.Max(e => e.ID) + 1;  //Autogenerate ID for DB/Table
            _employees.Add(model);
        }

        public void Commit()
        {
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null) return;
            else _employees.Remove(employee);
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return _employees;
        }

        public EmployeeViewModel GetById(int id)
        {
            return _employees.FirstOrDefault(x => x.ID == id);
        }
    }
}
