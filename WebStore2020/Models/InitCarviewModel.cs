using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore2020.Models
{
    public class InitCarViewModel
    {

        public List<InitCarViewModel> carList = new List<InitCarViewModel>();
        public string[] model = { "BMW", "Toyota", "Audi", "Nissan", "Lexus", "Opel", "Mazda", "Seat", "Volvo", "Saab", "Alfa Romeo" };
        public string[] engine = { "Petrol 2.0T", "Diesel 2.0T", "Petrol 1.6T", "Petrol 2.5T", "Diesel 1.8T", "Diesel 1.4T", "Hybrid 2.0", "Petrol 3.5", "Electric" };
        public string[] transmission = { "Manual gearbox", "Semi-automatic", "Automatic transmission" };
        public string[] colour = { "Red", "White", "Black", "Yellow", "Grey", "Silver", "Green", "Brown", "Gold", "Blue" };
        public string[] interiorColour = { "Black", "Grey", "Beige", "Brown", "White", "Red" };
        public string[] condition = { "New", "Used" };
        Random random = new Random();
        public InitCarViewModel() 
        {
                Model = model[random.Next(0, model.Length - 1)];
                Engine = engine[random.Next(0, engine.Length - 1)];
                Transmission = transmission[random.Next(0, transmission.Length - 1)];
                Colour = colour[random.Next(0, colour.Length - 1)];
                InteriorColour = interiorColour[random.Next(0, interiorColour.Length - 1)];
                Condition = condition[random.Next(0, condition.Length - 1)];
                Price = random.Next(70, 250).ToString() + "00$ ";
        }
        public  List<InitCarViewModel> GetInit()
        {
            carList = new List<InitCarViewModel>();
            for (int i = 0; i < 50; i++)
            {
                InitCarViewModel model = new InitCarViewModel();
                model.ID = i + 1;
                carList.Add(model);
            }
            return carList;
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
