using System;
using System.Linq;
using System.Reflection;
using Dal.EfStuff;
using Dal.Helper.CustomAttribute;
using Dal.Interfases;
using Dal.Interfases.Repository;
using Dal.Interfases.Service;
using Dal.Model.Base;
using Dal.Repository;
using Dal.Service;
using MazeLogicCore.Builders;
using MazeLogicCore.Converters;
using MazeLogicCore.Interfases.Builders;
using MazeLogicCore.Interfases.Converters;
using MazeModelCore.Interfases.Base;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Interfases.Models;
using MazeModelCore.Models;
using MazeWebApp.Helper.CustomerAttribute;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddScoped<IGameRepository, GameRepository>();
            //services.AddScoped<IPlayService, PlayService>();

            RegistretionRepository(services);
            RegesterByAttribute(services, typeof(UseDi));
            RegesterByAttribute(services, typeof(MazeWebDi));

            services.AddScoped<IHero, Hero>();
            services.AddScoped<IMazeBuilder, MazeBuilder>();
            services.AddScoped<IConverter<IMaze, IModelBase[,]>, MazeToEntityArrayConverter>();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void RegistretionRepository(IServiceCollection services)
        {
            var iBaseRepositoryTypeName = typeof(IRepository<>).Name;
            var dalTypes = Assembly.GetAssembly(typeof(BaseModel)).GetTypes();
            var iRepositoryTypes =
                dalTypes.Where(t => t.IsInterface && t.GetInterfaces().Any(i => i.Name == iBaseRepositoryTypeName));

            foreach (var interfase in iRepositoryTypes)
            {
                var repositoryType =
                    dalTypes.SingleOrDefault(t => t.IsClass && t.GetInterfaces().Any(i => i.FullName == interfase.FullName));
                if (repositoryType != null)
                {
                    services.AddScoped(interfase, repositoryType);
                }
            }
        }

        public void RegesterByAttribute(IServiceCollection service, Type attribyte)
        {
            var dalTypes = Assembly.GetAssembly(attribyte).GetTypes();
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
