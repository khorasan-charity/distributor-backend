using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeteorCommon;
using MeteorCommon.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Distributor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = DefaultLogger
                .Config("Mahak Distributor")
                .CreateLogger();

            try
            {
                Log.Debug("app is starting");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "app terminated unexpectedly");
            }
            finally
            {
                Log.Information("good bye");
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseSerilog();
                });

    }
}