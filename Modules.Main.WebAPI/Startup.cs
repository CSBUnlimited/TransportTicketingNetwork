using System.Text;
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
using Modules.Main.Core.Services;
using Modules.Main.Services;
using Serilog;
using TransportTicketingNetwork.Database;
using Utilities.Exception.Common.Filters;
using Utilities.Logging.Common.Configurations;
using Utilities.Logging.Common.Filters;

namespace Modules.Main.WebAPI
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configurations
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Injecting configurations</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration().ConfigureSerilog(configuration);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup DbContext Connection String
            services.AddDbContext<TransportTicketingNetworkDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

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
            services.SwaggerConfigureServices(Configuration.GetSection("Swagger")["CommentsXMLFilePath"]);

            //Add Services
            services.AddSingleton<IRouteService, RouteService>();

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
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                options.Filters.Add(typeof(ActivityLogActionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
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
            DbContextOptionsBuilder<TransportTicketingNetworkDbContext> optionsBuilder = new DbContextOptionsBuilder<TransportTicketingNetworkDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));

            using (TransportTicketingNetworkDbContext context = new TransportTicketingNetworkDbContext(optionsBuilder.Options))
            {
                context.InitializeDatabase();
            }
        }
    }
}
