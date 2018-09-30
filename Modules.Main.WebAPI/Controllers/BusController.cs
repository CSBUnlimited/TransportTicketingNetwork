using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.Bus;
using Modules.Main.ViewModels;
using Utilities.Exception.Models;

namespace Modules.Main.WebAPI.Controllers
{
    /// <summary>
    /// Buses Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly ILogger<BusController> _logger;
        private readonly IBusService _busService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        /// <param name="busService">Bus Service</param>
        public BusController(ILogger<BusController> logger, IBusService busService)
        {
            _logger = logger;
            _busService = busService;
        }

        /// <summary>
        /// This end point have a NullReferenceException which is inner exception.
        /// Outer exception is an ArgumentException.
        /// </summary>
        /// <returns>BusResponse</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        [HttpGet(Name = "GetBusList")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBusList()
        {
            BusResponse response = new BusResponse();

            try
            {
                response.BusViewModels = await _busService.GetBusListAsync();
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                // This line will throw a ArgumentException
                throw new ArgumentException("This is a test Argument Exception.", ex);
            }

            return StatusCode(response.Status, response);
        }


        /// <summary>
        /// Login UserAsync - Async
        /// </summary>
        /// <param name="busRequest">FromBody - UserRequest</param>
        /// <returns>BusResponse</returns>
        [HttpPost(Name = "AddBus")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddBus([FromBody]BusRequest busRequest)
        {
            BusResponse response = new BusResponse();

            try
            {

                response.BusViewModels = new List<BusViewModel>();

                {
                    await _busService.AddBusAsync(busRequest.BusViewModel);
                };

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