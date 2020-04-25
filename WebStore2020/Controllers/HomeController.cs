using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webstore.Infrastructure;

namespace Webstore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [SimpleActionFilter]
        public IActionResult Blog()  //<controller>/Blog
        {
            return View();
        }
        public IActionResult BlogSingle()  //<controller>/BlogSingle
        {
            return View();
        }
        public IActionResult Cart()  //<controller>/Cart
        {
            return View();
        }
        public IActionResult Checkout()  //<controller>/Checkout
        {
            return View();
        }
        public IActionResult ContactUs()  //<controller>/ContactUs
        {
            return View();
        }
        public IActionResult Login()  //<controller>/Login
        {
            return View();
        }
        public IActionResult NotFound()  //<controller>/NotFound
        {
            return View();
        }


    }
}