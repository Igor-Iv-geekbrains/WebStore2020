using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore2020.Infrastructure.Interfaces;
using WebStore2020.Models;

namespace WebStore2020.Controllers
{
    
    [Route("users")]
    public class EmloyeeController : Controller
    {
        private readonly IEmployeeService _employeeService;// _employees;
        public EmloyeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        //GET: /users/all
        [Route("all")]
        public IActionResult Index()
        {
            //return Content("Hello from home controller");
            return View(_employeeService.GetAll());
        }

        //GET: /users/{id}
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            //return Content("Hello from home controller");
            return View(_employeeService.GetById(id));
        }
        [Route("edit/{id?}")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //return Content("Hello from home controller");
            if(!id.HasValue)return View(new EmployeeViewModel());

            var model = _employeeService.GetById(id.Value);
            if (model == null) return NotFound();
            return View(model);
        }
        [Route("edit/{id?}")]
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model.ID > 0)
            {
                var dbItem = _employeeService.GetById(model.ID);
                if (ReferenceEquals(dbItem, null)) return NotFound();
                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Patronymic = model.Patronymic;
                dbItem.Age = model.Age;
                dbItem.Position = model.Position;
            }
            else _employeeService.AddNew(model);
            _employeeService.Commit();
            return RedirectToAction(nameof(Index));
           
        }
    }
}