﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Authorization.Core.DataAccess;
using Utilities.Authorization.Core.Repositories;
using Utilities.Authorization.Core.Services;
using Utilities.Authorization.DataAccess;
using Utilities.Authorization.Repositories;
using Utilities.Authorization.Services;

namespace Utilities.Authorization.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        /// <summary>
        /// Register Dependencies
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection RegisterAuthorizationDependencies(this IServiceCollection services)
        {
            #region Other - Dependancies

            // To get authentication token info
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

            #region Repository - Dependencies

            services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();

            #endregion

            #region UnitOfWork - Dependencies

            services.AddScoped<IAuthorizationUnitOfWork, AuthorizationUnitOfWork>();

            #endregion

            #region Service - Dependencies

            services.AddScoped<IAuthorizationService, AuthorizationService>();

            #endregion

            return services;
        }
    }
}
