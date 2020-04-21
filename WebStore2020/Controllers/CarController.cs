using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore2020.Models;
using WebStore2020;
using WebStore2020.Infrastructure.Interfaces;

namespace WebStore2020.Controllers
{

    [Route("vehicle")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        //List<CarViewModel> carViewModels = new List<CarViewModel>();
    public CarController(ICarService carService)
        {
            //CarViewModel carView = new CarViewModel();
            //carViewModels = carView.GetCar((Program.modelList));
            _carService = carService;
        }

        [Route("all")]
        public IActionResult Index()
        {
            return View(_carService.GetAll()/*carViewModels*/);
        }
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            //return Content("Hello from home controller");
           return View(_carService.GetById( id));
        }
        [Route("edit/{id?}")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //return Content("Hello from home controller");
            if (!id.HasValue) return View(new CarViewModel());

            var model = _carService.GetById(id.Value);
            if (model == null) return NotFound();
            return View(model);
        }
        [Route("edit/{id?}")]
        [HttpPost]
        public IActionResult Edit(CarViewModel carModel)
        {
            if (carModel.ID > 0)
            {
                //CarViewModel carView = new CarViewModel();
                var dbItem = Program.modelList.FirstOrDefault(x => x.ID == carModel.ID);
                //   var dbItem = _carService.GetById(carModel.ID);
                if (ReferenceEquals(dbItem, null)) return NotFound();
                // CarViewModel carView = new CarViewModel();
                dbItem.Colour = carModel.Colour;
                dbItem.Condition = carModel.Condition;
                dbItem.Engine = carModel.Engine;
                dbItem.ID = carModel.ID;
                dbItem.Model = carModel.Model;
                dbItem.Transmission = carModel.Transmission;
                dbItem.InteriorColour = carModel.InteriorColour;
                dbItem.Price = carModel.Price;
            }
            else
            {
                var dbItem = new InitCarViewModel();
                _carService.AddNew(dbItem, carModel);
            } 
            _carService.Commit();
            return RedirectToAction(nameof(Index));

        }
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _carService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
