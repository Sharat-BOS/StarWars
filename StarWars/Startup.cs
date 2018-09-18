using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Models;
namespace StarWars
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Notes: In startup class configure Service Method is called First.
        public void ConfigureServices(IServiceCollection services)
        {   
            //Register Services here System or Custom Services.
            //System Services
            services.AddMvc();
            //Built in dependency injection system

            //Service are objects that have certain functionality of other parts of the application 
            //you can register system services or our own services

            //Registering Custom services,
            //Add transient method means when anyone  asks for IPieRpository a new Mock Pie Repository will be returned.
            services.AddTransient<IPieRepository, MockPieRepository>();

            ////Add Singleton method means whenever anyone  asks for IPieRpository only single instance Mock Pie Repository will be created and returned. This same instance of MockPie Repository is returned every time.
            //services.AddSingleton<IPieRepository, MockPieRepository>();

            ////Add Scoped method is kid of in between singleton and Transent, it means whenever anyone asks for IPieRepository same instance Mock Pie Repository will be returned as long as request is in scope, when it is out of scope a new instance of MockPie repository is created. 
            //services.AddScoped<IPieRepository, MockPieRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Notes: In startup class configure is called after Configure Services Method. Here we setup request pipeline. After that application is ready to handle incoming requests.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Setup Request Pipe line 
            //Request Pipe line consists of number of components chained behind one other
            //These are so called middle ware components
            //These components will intercept or handle incoming HTTP requests.
            //These middle ware can alter the request or response and/or(just simply without changes) pass on the request/ response to other components in the pipe line. 
            // All the Middle ware defined here are in pipe line and the order in which they are defined are important.
            //MVC Middleware must be at the end of the pipe line.

            if (env.IsDevelopment())
            {
                //Error Pages For Exceptions. when some application goes wrong it will not throw yellow page of death. it will show developer error page.
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //provides support for Text only status codes pages for http error codes between 400-599
            app.UseStatusCodePages();
            //Serve Static Files 
            app.UseStaticFiles();
            //Use MVC with specified routes only one route is defined because it is a single page applciation.
            app.UseMvc(routes =>
            {
               

               
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "Pie",
                   template: "{controller=Pie}/{action=List}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
