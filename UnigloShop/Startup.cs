using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using UnigloShop.Controllers;
using UnigloShop.Data;

namespace UnigloShop
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
            services.AddDbContext<UnigloDataContext>(cfg =>
            {
                cfg.UseInMemoryDatabase("UnigloDatabase");
            });
            services.AddTransient<UnigloDataContext>();
            services.AddTransient<UnigloDataSeeder>();
            services.AddScoped<IUnigloRepository, UnigloRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.Add(ServiceDescriptor.Singleton<ILoggerFactory, LoggerFactory>());
            //services.AddSingleton<ILoggingBuilder>();
          //  services.AddSingleton<ILogger>();
           services.Add(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(Logger<>)));

            services.AddLogging(cfg => cfg.AddConsole()).AddTransient<ProductsController>();
  /*          var loggingProvider = services.AddLogging().BuildServiceProvider();

            loggingProvider.GetService<ILoggerFactory>*/
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

    }
}
