using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Distributor.Messages.Database;
using MeteorCommon;
using MeteorCommon.Database;
using MeteorCommon.Database.Sqlite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Distributor
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
            services.AddControllers();
            Directory.CreateDirectory("data");
            EnvVars.SetDefaultValue(EnvVarKeys.DbUri, "Data Source=data\\main.db");
            services.AddSingleton<IDbConnectionFactory, SqliteDbConnectionFactory>();
            services.AddScoped<LazyDbConnection>();
            
            using var lazyDbConnection = new LazyDbConnection(new SqliteDbConnectionFactory());
            new CreateDatabase(lazyDbConnection).ExecuteAsync().Wait();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}