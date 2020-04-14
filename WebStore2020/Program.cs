using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebStore2020.Controllers;
using WebStore2020.Models;


namespace WebStore2020
{
    public class Program
    {
        public static InitCarViewModel model = new InitCarViewModel();
        public static List<InitCarViewModel> modelList = new List<InitCarViewModel>();
        
        public static void Main(string[] args)
        {
            modelList = model.GetInit();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
