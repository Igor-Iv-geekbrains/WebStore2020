using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore2020.Models;

namespace WebStore2020.Controllers
{
    public class EmloyeeController : Controller
    {
        List<EmployeeViewModel> _employees = new List<EmployeeViewModel>
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
        //GET: /controller
        public IActionResult Index()
        {
            //return Content("Hello from home controller");
            return View(_employees);
        }

        //GET: /controller/details/id
        public IActionResult Details(int id)
        {
            //return Content("Hello from home controller");
            return View(_employees.FirstOrDefault(x => x.ID == id));
        }
    }
}