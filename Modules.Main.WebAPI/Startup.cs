﻿using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Modules.Main.Common.Configurations;
using Modules.Main.Database;
using Serilog;
using Utilities.Logging.Common.Configurations;
using Utilities.Logging.Common.Filters;

namespace Modules.Main.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration().ConfigureSerilog(configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup DbContext Connection String
            services.AddDbContext<MainDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            #region Add Cors
            // Allow any origin to access
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            #endregion

            #region Auto Mapper Configs

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            #endregion

            // Dependency Injection
            services.RegisterDependencies();

            // Swagger Configure Services
            services.SwaggerConfigureServices();

            // Add Authentication Services
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("ApplicationSettings")["AuthenticationEncodingKey"].ToString())),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ActivityLogActionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Access-Control-Allow-Origin
            app.UseCors("AllowAll");

            // Enable authentication middleware
            app.UseAuthentication();

            app.UseMvc();

            //Swagger Configure
            app.UseSwaggerConfigure();

            // Database Initialization 
            //DbContextOptionsBuilder<MainDbContext> optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));

            //using (MainDbContext context = new MainDbContext(optionsBuilder.Options))
            //{
            //    Console.WriteLine("Database Migration started...");
            //    //context.InitializeDatabase();
            //    Console.WriteLine("Database Migrated and Seeded...");
            //}
        }
    }
}
