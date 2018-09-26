using System;
using System.Collections.Generic;
using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.DTOs.TestLog;
using Modules.Main.ViewModels;
using Utilities.Exception.Models;
using Utilities.Logging.Common.Attributes;

namespace Modules.Main.WebAPI.Controllers
{
    /// <summary>
    /// Log Testings Controller - Purpose is to test logs are working correctly
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogTestingsController : ControllerBase
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly ILogger<UsersController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        public LogTestingsController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This end point enabled automatic runtime logs
        /// For every request there will two logs. One for the request and other for response.
        /// This method can occur validation exceptions
        /// </summary>
        /// <param name="testLogRequest">FromBody - TestLogRequest</param>
        /// <returns>TestLogResponse</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        [HttpPost(Name = "EnabledActivityLogs")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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
                throw new GlobalException(ex, response);
            }

            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// This end point will throw a NullReferenceException and it will handle by Global error handler
        /// </summary>
        /// <returns>UserResponse</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        [HttpGet(Name = "EnabledActivityWithUnexpectedExceptionLogs")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [EnableActivityLog]
        public IActionResult EnabledActivityWithUnexpectedExceptionLogs()
        {
            TestLogResponse response = new TestLogResponse();

            // This line will throw a NullReferenceException
            // ReSharper disable once UnusedVariable
            string temp = response.TestLogViewModel.ToString();

            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// This end point have a NullReferenceException which is inner exception.
        /// Outer exception is an ArgumentException.
        /// </summary>
        /// <returns>UserResponse</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        [HttpGet(Name = "EnabledActivityWithUnexpectedExceptionWithOuterExceptionLogs")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [EnableActivityLog]
        public IActionResult EnabledActivityWithUnexpectedExceptionWithOuterExceptionLogs()
        {
            TestLogResponse response = new TestLogResponse();

            try
            {
                // This line will throw a NullReferenceException
                // ReSharper disable once UnusedVariable
                string temp = response.TestLogViewModel.ToString();
            }
            catch (Exception ex)
            {
                // This line will throw a ArgumentException
                throw new ArgumentException("This is a test Argument Exception.", ex);
            }

            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// This end point have a NullReferenceException it will throw as GlobalException.
        /// Will handle by Global error handler
        /// </summary>
        /// <returns>UserResponse</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        [HttpGet(Name = "EnabledActivityWithUnexpectedExceptionUsingGlobalExceptionLogs")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [EnableActivityLog]
        public IActionResult EnabledActivityWithUnexpectedExceptionUsingGlobalExceptionLogs()
        {
            TestLogResponse response = new TestLogResponse();

            try
            {
                // This line will throw a NullReferenceException
                // ReSharper disable once UnusedVariable
                string temp = response.TestLogViewModel.ToString();
            }
            catch (Exception ex)
            {
                throw new GlobalException(ex, response);
            }

            return StatusCode(response.Status, response);
        }
    }
}