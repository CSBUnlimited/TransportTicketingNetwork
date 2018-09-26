using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.Login;
using Modules.Main.DTOs.User;
using Modules.Main.ViewModels;
using Utilities.Exception.Models;
using Utilities.Logging.Common.Attributes;

namespace Modules.Main.WebAPI.Controllers
{

    /// <summary>
    /// Users Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableActivityLog]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        /// <param name="userService">User Service</param>
        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Login UserAsync - Async
        /// </summary>
        /// <param name="loginRequest">FromBody - UserRequest</param>
        /// <returns>LoginResponse</returns>
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
        /// User Registration - Async
        /// </summary>
        /// <param name="userRequest">FromBody - UserRequest</param>
        /// <returns>UserResponse</returns>
        [HttpPost(Name = "UserRegistrationAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UserRegistrationAsync([FromBody]UserRequest userRequest)
        {
            _logger.LogInformation("This is a test Warning message {@UserRequest}", userRequest);

            await Task.Run(() => { });

            return StatusCode((int)HttpStatusCode.OK, userRequest);
        }
    }
}