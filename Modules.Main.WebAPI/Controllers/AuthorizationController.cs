using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Main.DTOs.User;

namespace Modules.Main.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        /// <summary>
        /// User Registration - Async
        /// </summary>
        /// <param name="userRequest">FromBody - UserRequest</param>
        /// <returns>UserResponse</returns>
        /// <response code="200">User registered</response>
        /// <response code="400">Bad request by client</response>
        /// <response code="500">Something went wrong from Server side</response>
        [HttpPost(Name = "UserRegistrationAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UserRegistrationAsync([FromBody]UserRequest userRequest)
        {
            

            return StatusCode((int)HttpStatusCode.OK);
        }
    }
}