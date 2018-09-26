using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Base.Services;
using Common.Methods;
using Common.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Utilities.Authorization.Core.DataAccess;
using Utilities.Authorization.Core.Services;

namespace Utilities.Authorization.Services
{
    public class AuthorizationService : BaseService, IAuthorizationService
    {
        private readonly IAuthorizationUnitOfWork _authorizationUnitOfWork;
        private readonly IConfiguration _configuration;

        public AuthorizationService(IAuthorizationUnitOfWork authorizationUnitOfWork, IConfiguration configuration)
        {
            _authorizationUnitOfWork = authorizationUnitOfWork;
            _configuration = configuration;
        }

        /// <summary>
        /// Only responsibility of this method is to throw a ValidationException
        /// </summary>
        /// <param name="message">Optional. Validation error message</param>
        private void ThrowInvalidUsernameOrPasswordException(string message = "Invalid Username or Password")
        {
            throw new ValidationException(message);
        }

        /// <summary>
        /// Authenticate User Login - Async.
        /// Check user is available.
        /// Check user is blocked.
        /// Check user given password is correct.
        /// Create token to the user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Encoded Password</param>
        /// <returns>Authentication Token</returns>
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public async Task<string> AuthenticateLoginAsync(string username, string password)
        {
            ApplicationUser applicationUser = await _authorizationUnitOfWork.AuthorizationRepository
                .GetApplicationUserByUsernameAndExpireDateAsync(username);

            // Check user is available
            if (applicationUser == null)
            {
                ThrowInvalidUsernameOrPasswordException();
            }

            // Check whether user is block or not
            if (applicationUser.IsBlocked)
            {
                ThrowInvalidUsernameOrPasswordException("This user blocked. Please contact system admins");
            }

            // Check whether user given password is correct
            if (!AuthenticationMethods.IsPasswordVerified(password, applicationUser.PasswordHash,
                applicationUser.PasswordSalt))
            {
                ThrowInvalidUsernameOrPasswordException();
            }

            // Create token to the user
            string sessionHash = Guid.NewGuid().ToString();
            string token = TokenMethods.GenerateTokenViewModelForUser(
                _configuration.GetSection("ApplicationSettings")["AuthenticationEncodingKey"],
                sessionHash,
                applicationUser.Username,
                applicationUser.User);

            // Enter the token hash to the database
            using (IDbContextTransaction transaction = await _authorizationUnitOfWork.BeginTransactionAsync())
            {
                ApplicationUserToken applicationUserToken = new ApplicationUserToken()
                {
                    ApplicationUser = applicationUser,
                    SessionHash = sessionHash,
                    ExpireDateTime = DateTime.UtcNow.AddDays(1)
                };

                try
                {
                    await _authorizationUnitOfWork.AuthorizationRepository.AddApplicationUserTokenAsync(applicationUserToken);
                    await _authorizationUnitOfWork.CompleteAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return token;
        }

    }
}
