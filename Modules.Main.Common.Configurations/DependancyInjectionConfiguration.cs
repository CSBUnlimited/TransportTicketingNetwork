using Microsoft.Extensions.DependencyInjection;
using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Repositories;
using Modules.Main.Core.Services;
using Modules.Main.DataAccess;
using Modules.Main.Repositories;
using Modules.Main.Services;
using Utilities.Authorization.Configurations;

namespace Modules.Main.Common.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        /// <summary>
        /// Register Dependencies
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            #region Other - Dependancies

            services.RegisterAuthorizationDependencies();

            #endregion

            #region Repository - Dependencies

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IBusRepository, BusRepository>();

            #endregion

            #region UnitOfWork - Dependencies

            services.AddScoped<IMainUnitOfWork, MainUnitOfWork>();

            #endregion

            #region Service - Dependencies

            services.AddScoped<IUserService, UserService>();

            #endregion

            return services;
        }
    }
}
