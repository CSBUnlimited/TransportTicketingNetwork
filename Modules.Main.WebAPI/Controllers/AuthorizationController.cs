using System;
using System.Net;
using System.Threading.Tasks;
using Common.Base.DTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.Login;
using Modules.Main.DTOs.User;
using Modules.Main.ViewModels;
using Utilities.Exception.Models;

namespace Modules.Main.WebAPI.Controllers
{

    /// <summary>
    /// Users Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        /// <param name="userService">User Service</param>
        public AuthorizationController(ILogger<AuthorizationController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
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
                    response.AuthenticationToken = await _userService.UserLoginAsync(loginRequest.LoginViewModel);
                }
                else
                {
                    throw new ValidationException("Invalid username or Password");
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
                await _userService.UserLogoutAsync();

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
                response.AuthenticationToken = await _userService.RenewAuthenticationTokenAsync();

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