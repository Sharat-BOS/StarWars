using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StarWars
{
    public class Program
    {
        //like console application it has Main function
        public static void Main(string[] args)
        {
            //Application starting. Here we build a Web host and run it.
            BuildWebHost(args).Run();
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            //When building web host we specify the startup class using UseStartup() call
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
