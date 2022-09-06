using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{    public class Program
    {
       // public static void Main(string[] args)
        public static async Task  Main(string[] args)
        {
            Console.WriteLine("\n\n>>>>>>>>  <<<<<<<<<<<\n API - Main - Start \n>>>>>>>>  <<<<<<<<<<<\n\n");
            //CreateHostBuilder(args).Build().Run();
           
            var host = CreateHostBuilder(args).Build();  // don't call .Run(), just build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await Seed.SeedUsers(context);
            }
            catch (Exception ex)
            {   Console.WriteLine("\n API - Main - Error: " + ex.Message);  
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "API - Main - An error occurred during migration.");         
            }

            // now start the app
            await host.RunAsync();



            Console.WriteLine("\n\n>>>>>>>>  <<<<<<<<<<<\n API - Main - Stop \n>>>>>>>>  <<<<<<<<<<<\n\n");

            Console.WriteLine("\n\n>>>>>>>>  <<<<<<<<<<<\n API - Main - Stop \n>>>>>>>>  <<<<<<<<<<<\n\n");

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
