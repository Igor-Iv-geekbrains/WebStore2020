using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WebStore.Infrastructure;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Services;
using WebStore.Models;

namespace WebStore
{

    public class Startup
    {

        private readonly IConfiguration _configuration;


        public Startup(IConfiguration configuration)
        {
           _configuration = configuration;
           
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(SimpleActionFilter));
            });
            services.AddSingleton<IEmployeeService, InMemoryEmployeeService>();   //services lives all time
            services.AddSingleton<ICarService,  InitCarViewModel>();
            services.AddSingleton<IProductService, InMemoryProductService>();
            //services.AddScoped<IEmployeeService, InMemoryEmployeeService>();        //services lives http request time
            //services.AddTransient<IEmployeeService, InMemoryEmployeeService>();   //rervic=es lives ***
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); //use folder wwwroot

           // app.Map("/index", CustomIndexHandler);
           // app.UseMiddleware<TokenMiddleware>();

            //UseSample(app);
            

            app.UseRouting();
            var helloMsg = _configuration["Logging:LogLevel:Default"];
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");  //path template

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");  //path template
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Home");
                //});
            });
            //app.UseMvcWithDefaultRoute();
            RunSample(app);
        }

        private void UseSample(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
           {
               bool isError = false;
               //....
               if (isError)
               {
                   await context.Response.WriteAsync("Hi from use ");
               }
               else { await next.Invoke(); }
           });
        }

        private void CustomIndexHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
        private void RunSample(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hi from app.Run");
            });
        }

    }
}
