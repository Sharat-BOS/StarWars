using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StarWars.Models;

namespace StarWars
{
    public class Program
    {
        //like console application it has Main function
        public static void Main(string[] args)
        {
            //Application starting. Here we build a Web host and run it.
            //BuildWebHost(args).Run();
            //create host
            var host = BuildWebHost(args);
            //get scope current scope
            using (var scope = host.Services.CreateScope()) {
                try
                {
                    // Dependency injection get AppDBcontext and call seed method to see if DB is empty and then Insert Seed Data.
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    DbInitializer.Seed(context);

                }
                catch (Exception ex)
                {
                    //log  
                    //_logger.LogError($"Something went wrong: {ex}");
                    //return StatusCode(500, "Internal server error");
                }

            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            //When building web host we specify the startup class using UseStartup() call
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
