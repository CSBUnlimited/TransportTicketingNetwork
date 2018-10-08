using System;
using System.Net;
using System.Threading.Tasks;
using Common.Base.DTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.DTOs.Login;
using Modules.Main.ViewModels;
using Utilities.Exception.Models;
using IAuthorizationService = Modules.Main.Core.Services.IAuthorizationService;

namespace Modules.Main.WebAPI.Controllers
{

    /// <summary>
    /// Authorization Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly IAuthorizationService _authorizationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        /// <param name="authorizationService">Authorization Service</param>
        public AuthorizationController(ILogger<AuthorizationController> logger, IAuthorizationService authorizationService)
        {
            _logger = logger;
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// Login User - Async
        /// </summary>
        /// <param name="loginRequest">FromBody - UserRequest</param>
        /// <returns>LoginResponse</returns>
        [AllowAnonymous]
        [HttpPost(Name = "LoginUserAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoginUserAsync([FromBody]LoginRequest loginRequest)
        {
            LoginResponse response = new LoginResponse();

            try
            {
                ValidationResult result = new LoginValidator().Validate(loginRequest.LoginViewModel);

                if (result.IsValid)
                {
                    response.AuthenticationToken = await _authorizationService.UserLoginAsync(loginRequest.LoginViewModel);
                }
                else
                {
                    throw new ValidationException("Invalid Username or Password.");
                }

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                throw new GlobalException(ex, response);
            }

            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Logout User - Async
        /// </summary>
        /// <returns>LoginResponse</returns>
        [HttpGet(Name = "LogoutUserAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LogoutUserAsync()
        {
            BaseResponse response = new BaseResponse();

            try
            {
                await _authorizationService.UserLogoutAsync();

                response.IsSuccess = true;
                response.Message = "User logged out";
                response.MessageDetails = "User logged out successfully.";
            }
            catch (Exception ex)
            {
                throw new GlobalException(ex, response);
            }

            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Renew Authentication Token - Async
        /// </summary>
        /// <returns>LoginResponse</returns>
        [HttpGet(Name = "RenewAuthenticationTokenAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RenewAuthenticationTokenAsync()
        {
            LoginResponse response = new LoginResponse();

            try
            {
                response.AuthenticationToken = await _authorizationService.RenewAuthenticationTokenAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                throw new GlobalException(ex, response);
            }

            return StatusCode(response.Status, response);
        }

        ///// <summary>
        ///// User Registration - Async
        ///// </summary>
        ///// <param name="userRequest">FromBody - UserRequest</param>
        ///// <returns>UserResponse</returns>
        //[HttpPost(Name = "UserRegistrationAsync")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> UserRegistrationAsync([FromBody]UserRequest userRequest)
        //{
        //    await Task.Run(() => { });

        //    return StatusCode((int)HttpStatusCode.OK, userRequest);
        //}


    }
}