using System.IO;
using Distributor.Messages.Database;
using MeteorCommon;
using MeteorCommon.AspCore.Utils;
using MeteorCommon.Database;
using MeteorCommon.Database.Sqlite;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
            services.AddControllers()
                .AddMeteorJsonConverters();
            Directory.CreateDirectory("data");
            EnvVars.SetDefaultValue(EnvVarKeys.DbUri, "Data Source=data/main.db");
            services.AddSingleton<IDbConnectionFactory, SqliteDbConnectionFactory>();
            services.AddScoped<LazyDbConnection>();

            using var lazyDbConnection = new LazyDbConnection(new SqliteDbConnectionFactory());
            new CreateDatabase(lazyDbConnection).ExecuteAsync().Wait();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Distributor API", Version = "v1"});
            });

            services.AddCors(x => x
                .AddDefaultPolicy(y => y
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()));
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://id.skyth.ir";
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        RoleClaimType = "role",
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidAudiences = new[] {"mahak.dist.admin", "mahak.dist.dist"}
                    };
                });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", builder =>
                    builder.RequireClaim("scope", "mahak.dist.admin"));
                
                options.AddPolicy("Distributor", builder =>
                    builder.RequireClaim("scope", "mahak.dist.dist"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Distributor API v1"); });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}