using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Models;
namespace StarWars
{
    public class Startup
    {
        //contains all information read out from appsettings.json and other configuration information
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        //Notes: In startup class configure Service Method is called First.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalDBConnection")));            
            //Register Services here System or Custom Services.
            //System Services
            services.AddMvc();
            //Built in dependency injection system

            //Service are objects that have certain functionality of other parts of the application 
            //you can register system services or our own services

            //Registering Custom services,
            //Add transient method means when anyone  asks for IPieRpository a new Mock Pie Repository will be returned.
            //Initialy we used MockPie Repository because we did not connect to database now that we are using EF to connect to DB we dont need Mock Data or MockPieRepository for Dependancy injection. so its commented.
            //services.AddTransient<IPieRepository, MockPieRepository>();
            
            services.AddTransient<IPieRepository, PieRepository>(); //newly Created Pie repository uses EF to connect to DB.
            services.AddTransient<IFactionRepository, FactionRepository>(); //newly Created Pie repository uses EF to connect to DB.
            services.AddTransient<IEpisodeRepository, EpisodeRepository>(); //newly Created Pie repository uses EF to connect to DB.
            services.AddTransient<ICharacterRepository, CharacterRepository>(); //newly Created Pie repository uses EF to connect to DB.
            services.AddTransient<ICharacterTypeRepository, CharacterTypeRepository>(); //newly Created Pie repository uses EF to connect to DB.
            services.AddTransient<ICharacterGroupRepository, CharacterGroupRepository>(); //newly Created Pie repository uses EF to connect to DB.
            services.AddTransient<IStarshipRepository, StarshipRepository>(); //newly Created Pie repository uses EF to connect to DB.
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new StarWarsSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<StarWarsQuery>() });
            services.AddScoped<StarWarsQuery>();




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
