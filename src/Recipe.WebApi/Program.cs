using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Recipe.Persistance;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Recipe.WebApi
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true)
            .Build();

        public static async Task Main(string[] args)
        {
            //var connectionString = Configuration.GetConnectionString("RecipeConnectionString");
  
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            //Serilog.Debugging.SelfLog.Enable(msg =>
            //{
            //    Debug.Print(msg);
            //    Debugger.Break();
            //});

            try
            {
                var iHost = await CreateHostBuilder(args)
                    .Build()
                    .MigrateRecipeDatabase();

                await iHost.RunAsync();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(Configuration)
                .UseSerilog()
                .UseStartup<Startup>();
    }
}
