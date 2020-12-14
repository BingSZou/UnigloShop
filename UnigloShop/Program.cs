using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnigloShop.Data;

namespace UnigloShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                                        .Build();

            RunSeeding(host);
            host.Run();
        }

        private static void RunSeeding(IHost host)
        {
            var scopedFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopedFactory.CreateScope() )
            {
                var seeder = scope.ServiceProvider.GetService<UnigloDataSeeder>();
                seeder.Seed();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
