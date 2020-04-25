using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    
    [Route("users")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;// _employees;
        public EmployeeController(IEmployeeService employeeService)
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
            if (model.Age <18 || model.Age > 100)
            {
                ModelState.AddModelError("Age", "Age ERROR");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
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
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}


