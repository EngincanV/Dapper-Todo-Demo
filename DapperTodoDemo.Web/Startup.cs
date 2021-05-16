using Autofac;
using AutoMapper;
using DapperTodoDemo.Application;
using DapperTodoDemo.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DapperTodoDemo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public ILifetimeScope AutofacContainer { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            
            //AutoMapper registration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TodoItemAutoMapperProfile>();
            });
            services.AddSingleton(config.CreateMapper());
        }

        //runs after ConfigureServices
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DapperTodoDemoApplicationModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); 
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}");
            });
        }
    }
}