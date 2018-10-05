using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Common.Base.Services;
using Common.Methods;
using Common.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Utilities.Authorization.Common.Models;
using Utilities.Authorization.Core.DataAccess;
using Utilities.Authorization.Core.Services;

namespace Utilities.Authorization.Services
{
    public sealed class AuthorizationService : BaseService, IAuthorizationService
    {
        private readonly IAuthorizationUnitOfWork _authorizationUnitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IRequestInformation _requestInformation;

        public AuthorizationService(IAuthorizationUnitOfWork authorizationUnitOfWork, IConfiguration configuration, IRequestInformation requestInformation)
        {
            _authorizationUnitOfWork = authorizationUnitOfWork;
            _configuration = configuration;
            _requestInformation = requestInformation;
        }

        /// <summary>
        /// Only responsibility of this method is to throw a ValidationException
        /// </summary>
        /// <param name="message">Optional. Validation error message</param>
        private void ThrowInvalidUsernameOrPasswordException(string message = "Invalid Username or Password.")
        {
            throw new ValidationException(message);
        }
        
        /// <summary>
        /// Is User Authorized - Async.
        /// Check whether user is available.
        /// Check whether sessionHash is valid.
        /// TODO: Check user have the permission to execute that controller or not.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="sessionHash">Session Hash</param>
        /// <returns>Whether authorized or not</returns>
        public async Task<bool> IsUserAuthorizedAsync(string username, string sessionHash)
        {
            // Check whether user is available
            bool isUserAuthorized =
                await _authorizationUnitOfWork.ApplicationUserRepository.IsApplicationUserAvailableWhichNotBlockedAndExpiredByUsernameAsync(username);

            // Check whether session hash is valid
            if (isUserAuthorized)
            {
                ApplicationUserToken applicationUserToken =
                    await _authorizationUnitOfWork.ApplicationUserTokenRepository
                        .GetApplicationUserTokenWhichNotExpiredBySessionHashAsync(sessionHash);

                isUserAuthorized = (applicationUserToken != null && applicationUserToken.SessionHash == sessionHash);
            }

            // TODO: Check user have the permission to execute that controller or not

            return isUserAuthorized;
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
            // Check user is available
            bool isApplicationUserAvailable = await _authorizationUnitOfWork.ApplicationUserRepository
                .IsApplicationUserAvailableWhichNotExpiredByUsernameAsync(username);

            if (!isApplicationUserAvailable)
            {
                ThrowInvalidUsernameOrPasswordException();
            }

            // Get the application user
            ApplicationUser applicationUser = await _authorizationUnitOfWork.ApplicationUserRepository
                .GetApplicationUserWhichNotExpiredByUsernameAsync(username);

            // Check whether user is blocked or not
            if (applicationUser.IsBlocked)
            {
                ThrowInvalidUsernameOrPasswordException("This user is blocked. Please contact system admins.");
            }

            // Check whether user given password is correct
            if (!AuthenticationMethods.IsPasswordVerified(password, applicationUser.PasswordHash,
                applicationUser.PasswordSalt))
            {
                ThrowInvalidUsernameOrPasswordException();
            }

            User user = await _authorizationUnitOfWork.UserRepository.GetUserByUsernameAsync(username);

            // Create token to the user
            string sessionHash = Guid.NewGuid().ToString();
            string token = TokenMethods.GenerateTokenViewModelForUser(
                _configuration.GetSection("ApplicationSettings")["AuthenticationEncodingKey"],
                sessionHash, applicationUser.Username, user);


            ApplicationUserToken applicationUserToken = new ApplicationUserToken()
            {
                ApplicationUserId = applicationUser.Id,
                SessionHash = sessionHash,
                ExpireDateTime = DateTime.UtcNow.AddDays(1)
            };

            // Enter the token hash to the database
            using (IDbContextTransaction transaction = await _authorizationUnitOfWork.BeginTransactionAsync())
            {
                try
                {

                    await _authorizationUnitOfWork.ApplicationUserTokenRepository.AddApplicationUserTokenAsync(applicationUserToken);
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

        /// <summary>
        /// Regenerate new token and expire the current token - Async.
        /// Check validity of current session hash
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public async Task<string> RenewAuthenticateTokenAndExpireOldTokenAsync()
        {
            // Get the current token's session hash
            ApplicationUserToken currentApplicationUserToken = await _authorizationUnitOfWork.ApplicationUserTokenRepository
                .GetApplicationUserTokenWhichNotExpiredBySessionHashAsync(_requestInformation.SessionHash);

            // Check current session hash with case sensitivity
            if (currentApplicationUserToken == null || currentApplicationUserToken.SessionHash != _requestInformation.SessionHash)
            {
                ThrowInvalidUsernameOrPasswordException("User is not correctly logged in.");
            }
            
            // Expire application user token
            currentApplicationUserToken.ExpireDateTime = DateTime.UtcNow;

            // Get the application user according to the token data
            ApplicationUser applicationUser =
                await _authorizationUnitOfWork.ApplicationUserRepository
                    .GetApplicationUserIncludingUserWhichNotBlockedAndExpiredByUsernameAsync(_requestInformation.RequestedUsername);

            // Check user is available
            if (applicationUser == null)
            {
                // Save expire token before exit
                using (IDbContextTransaction transaction = await _authorizationUnitOfWork.BeginTransactionAsync())
                {
                    try
                    {
                        await _authorizationUnitOfWork.CompleteAsync();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                ThrowInvalidUsernameOrPasswordException("User is not correctly logged in.");
            }

            // Check whether user is block or not
            if (applicationUser.IsBlocked)
            {
                // Save expire token before exit
                using (IDbContextTransaction transaction = await _authorizationUnitOfWork.BeginTransactionAsync())
                {
                    try
                    {
                        await _authorizationUnitOfWork.CompleteAsync();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                ThrowInvalidUsernameOrPasswordException("This user blocked. Please contact system admins.");
            }

            // Create new token to the user
            string sessionHash = Guid.NewGuid().ToString();
            string token = TokenMethods.GenerateTokenViewModelForUser(
                _configuration.GetSection("ApplicationSettings")["AuthenticationEncodingKey"],
                sessionHash, applicationUser.Username, applicationUser.User);
            
            ApplicationUserToken newApplicationUserToken = new ApplicationUserToken()
            {
                ApplicationUserId = applicationUser.Id,
                SessionHash = sessionHash,
                ExpireDateTime = DateTime.UtcNow.AddDays(1)
            };

            // Save data to the database
            using (IDbContextTransaction transaction = await _authorizationUnitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await _authorizationUnitOfWork.ApplicationUserTokenRepository.AddApplicationUserTokenAsync(newApplicationUserToken);
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

        /// <summary>
        /// Logout User - Async
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public async Task LogoutUserAsync()
        {
            // Get the current token's session hash
            ApplicationUserToken applicationUserToken = await _authorizationUnitOfWork.ApplicationUserTokenRepository
                .GetApplicationUserTokenWhichNotExpiredBySessionHashAsync(_requestInformation.SessionHash);

            // Check session hash with case sensitivity
            if (applicationUserToken == null || applicationUserToken.SessionHash != _requestInformation.SessionHash)
            {
                ThrowInvalidUsernameOrPasswordException("User is not correctly logged in");
            }

            // Expire application user token's expire datetime
            applicationUserToken.ExpireDateTime = DateTime.UtcNow;

            using (IDbContextTransaction transaction = await _authorizationUnitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await _authorizationUnitOfWork.CompleteAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
