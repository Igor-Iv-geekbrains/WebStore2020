using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore2020.Models
{
    public class CarViewModel
    {


        public List<CarViewModel> GetCar(List<InitCarViewModel> initList) 
        {
            List<CarViewModel> carViewModels = new List<CarViewModel>();

            foreach (var car in initList)
            {
                CarViewModel carView = new CarViewModel();
                carView.Colour = car.Colour;
                carView.Condition = car.Condition;
                carView.Engine = car.Engine;
                carView.ID = car.ID;
                carView.Model = car.Model;
                carView.Transmission = car.Transmission;
                carView.InteriorColour = car.InteriorColour;
                carView.Price = car.Price;
                carViewModels.Add(carView);
            }
            return carViewModels;
        }
        public int ID { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Colour { get; set; }
        public string InteriorColour { get; set; }
        public string Condition { get; set; }
        public string Price { get; set; }


    }
}
