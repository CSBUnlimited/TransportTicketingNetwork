using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Repositories;
using Modules.Main.Core.Services;
using Modules.Main.DataAccess;
using Modules.Main.Repositories;
using Modules.Main.Services;

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

            // To get authentication token info
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

            #region Repository - Dependencies

            services.AddScoped<IUserRepository, UserRepository>();

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
