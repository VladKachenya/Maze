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
using MazeWebCore.Helpers.Attributes;
using MazeWebCore.Interfaces.Repositories;
using MazeWebCore.Interfaces.Services;
using MazeWebCore.Sevices;

namespace MazeWebApp
{
    public class Startup
    {
        private readonly DependencyLogger _dependencyLogger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _dependencyLogger = new DependencyLogger();
            _dependencyLogger.Initialization();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceCollection), s => services);
            // manually registration of dependencies  
            services.AddScoped<IHero, Hero>();
            services.AddScoped<IMazeBuilder, MazeBuilder>();
            services.AddScoped<IConverter<IMaze, IModelBase[,]>, MazeToEntityArrayConverter>();
            services.AddScoped<IMazeToCharConverter, MazeToCharConverter>();

            // dbContext registration
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

            // add integrated services
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // dependencies registration by reflexion
            _dependencyLogger.RegesterMarkedTypes(services);
            //_dependencyLogger.RejesterPropertyIngection(services);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            IServiceProvider serviceProvider, IServiceCollection serviceCollection)
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
