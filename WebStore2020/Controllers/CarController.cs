using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore2020.Models;
using WebStore2020;


namespace WebStore2020.Controllers
{

    [Route("vehicle")]
    public class CarController : Controller
    {

        List<CarViewModel> carViewModels = new List<CarViewModel>();
    public CarController()
        {
            CarViewModel carView = new CarViewModel();
            carViewModels = carView.GetCar((Program.modelList));
        }

        [Route("all")]
        public IActionResult Index()
        {
            return View(carViewModels);
        }
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            //return Content("Hello from home controller");
           return View(carViewModels.FirstOrDefault(x => x.ID == id));
        }
    }
}