using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
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
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        /// <param name="authorizationService">Authorization Service</param>
        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Register User - Async
        /// </summary>
        /// <param name="userRequest">FromBody - UserExtRequest</param>
        /// <returns>UserResponse</returns>
        [AllowAnonymous]
        [HttpPost(Name = "RegisterUserAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterUserAsync([FromBody]UserExtRequest userRequest)
        {
            UserResponse response = new UserResponse();

            try
            {
                ValidationResult result = new UserExtValidator().Validate(userRequest.UserExtViewModel);

                if (result.IsValid)
                {
                    response.UserViewModel = await _userService.RegisterUserAsync(userRequest.UserExtViewModel);
                }
                else
                {
                    throw new ValidationException(result.Errors);
                }

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                throw new GlobalException(ex, response);
            }

            return StatusCode(response.Status, response);
        }
    }
}