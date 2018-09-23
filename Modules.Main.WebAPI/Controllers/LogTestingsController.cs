using System;
using System.Collections.Generic;
using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.DTOs.TestLog;
using Modules.Main.ViewModels;
using Utilities.Logging.Common.Attributes;

namespace Modules.Main.WebAPI.Controllers
{
    /// <summary>
    /// Log Testings Controller - Purpose is to test logs are working correctly
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LogTestingsController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        public LogTestingsController(ILogger<AuthorizationController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This end point enabled automatic runtime logs
        /// For every request there will two logs. One for the request and other for response
        /// </summary>
        /// <param name="testLogRequest">FromBody - TestLogRequest</param>
        /// <returns>UserResponse</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        /// <response code="500">Something went wrong from Server side</response>
        [HttpPost(Name = "EnabledActivityLogs")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [EnableActivityLog]
        public IActionResult EnabledActivityLogs([FromBody]TestLogRequest testLogRequest)
        {
            TestLogResponse response = new TestLogResponse();

            try
            {
                ValidationResult result = new TestLogValidator().Validate(testLogRequest.TestLogViewModel);

                if (result.IsValid)
                {
                    testLogRequest.TestLogViewModel.TestMessage = string.Concat(testLogRequest.TestLogViewModel.TestMessage, " - Appended in the controller level");
                    
                    response.TestLogViewModel = new List<TestLogViewModel>()
                    {
                        testLogRequest.TestLogViewModel
                    };

                    response.IsSuccess = true;
                }
                else
                {
                    throw new ValidationException(result.Errors);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return StatusCode(response.Status, response);
        }
    }
}