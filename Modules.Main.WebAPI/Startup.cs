using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Modules.Main.Common.Configurations;
using Modules.Main.Database;

namespace Modules.Main.WebAPI
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
            // Setup DbContext Connection String
            services.AddDbContext<MainDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            // Allow any origin to access 
            // Not secure but only for this Assignment
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Access-Control-Allow-Origin
            app.UseCors("AllowAll");




            app.UseMvc();

            //Swagger Configure
            app.UseSwaggerConfigure();

            // Database Initialization 
            DbContextOptionsBuilder<MainDbContext> optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));

            using (MainDbContext context = new MainDbContext(optionsBuilder.Options))
            {
                Console.WriteLine("Database Migration started...");
                //context.InitializeDatabase();
                Console.WriteLine("Database Migrated and Seeded...");
            }
        }
    }
}
