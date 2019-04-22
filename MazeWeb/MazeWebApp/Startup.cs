using Dal.EfStuff;
using Dal.Repository;
using MazeLogicCore.Builders;
using MazeLogicCore.Converters;
using MazeLogicCore.Interfases.Builders;
using MazeLogicCore.Interfases.Converters;
using MazeModelCore.Interfases.Base;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Interfases.Models;
using MazeModelCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using MazeWebCore.Entities.Base;
using MazeWebCore.Interfaces.Repositories;
using MazeWebCore.Interfaces.Services;
using MazeWebCore.Sevices;

namespace MazeWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IPlayService, PlayService>();

            // dependencies registration by reflexion
            //RegistretionRepository(services);


            // manually registration of dependencies  
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IHero, Hero>();
            services.AddScoped<IMazeBuilder, MazeBuilder>();
            services.AddScoped<IConverter<IMaze, IModelBase[,]>, MazeToEntityArrayConverter>();
            services.AddScoped<IMazeToCharConverter, MazeToCharConverter>();

            RegesterByAttribute(services, typeof(string));

            // dbContext registration
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

            // add integrated services
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        public void RegesterByAttribute(IServiceCollection service, Type attribyte)
        {
            var curDir = Environment.CurrentDirectory;
            var appPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var assemblies = Directory.GetFiles(appPath);
            //foreach (var assembly in assemblies)
            //{
            //    var asdf = 
            //}
            List<Type> dalTypes = new List<Type>();
            foreach (var assembly in assemblies)
            {
                dalTypes.AddRange(Assembly.LoadFrom(assembly).GetTypes());
            }

            //var dalTypes = Assembly.GetAssembly(attribyte).GetTypes();
            var markedInterfaces = dalTypes.Where(t =>
                t.IsInterface && t.GetCustomAttributes().Any(at => at.GetType().FullName == attribyte.FullName));
            var markedClasses = dalTypes.Where(t =>
                t.IsClass && t.GetCustomAttributes().Any(at => at.GetType().FullName == attribyte.FullName)).ToList();
            foreach (var interfaces in markedInterfaces)
            {
                var childClass =
                    markedClasses.SingleOrDefault(t => t.GetInterfaces().Any(i => i.FullName == interfaces.FullName));
                if (childClass != null)
                {
                    markedClasses.Remove(childClass);
                    service.AddScoped(interfaces, childClass);
                }
            }
            markedClasses.ForEach(el => service.AddScoped(el));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
