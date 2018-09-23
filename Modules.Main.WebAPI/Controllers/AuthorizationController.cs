using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.DTOs.User;
using Utilities.Logging.Common.Attributes;

namespace Modules.Main.WebAPI.Controllers
{

    /// <summary>
    /// Authorization Controller
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableActivityLog]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        public AuthorizationController(ILogger<AuthorizationController> logger)
        {
            _logger = logger;
        }

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
            _logger.LogInformation("This is a test Warning message {@UserRequest}", userRequest);

            await Task.Run(() => { });
            
            return StatusCode((int)HttpStatusCode.OK, userRequest);
        }
    }
}