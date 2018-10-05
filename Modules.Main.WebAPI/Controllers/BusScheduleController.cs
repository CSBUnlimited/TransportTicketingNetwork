using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.BusSchedule;

namespace Modules.Main.WebAPI.Controllers
{
    /// <summary>
    /// BusSchedules Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusScheduleController : ControllerBase
    {
        private readonly ILogger<BusScheduleController> _logger;
        private readonly IBusScheduleService _busScheduleService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        /// <param name="busScheduleService">BusSchedule Service</param>
        public BusScheduleController(ILogger<BusScheduleController> logger, IBusScheduleService busScheduleService)
        {
            _logger = logger;
            _busScheduleService = busScheduleService;
        }

        /// <summary>
        /// This end point have a NullReferenceException which is inner exception.
        /// Outer exception is an ArgumentException.
        /// </summary>
        /// <returns>BusResponse</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        [HttpGet(Name = "GetBusScheduleList")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBusScheduleList()
        {
            BusScheduleResponse response = new BusScheduleResponse();

            try
            {
                response.BusScheduleViewModels = await _busScheduleService.GetBusScheduleListAsync();
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                // This line will throw a ArgumentException
                throw new ArgumentException("This is a test Argument Exception.", ex);
            }

            return StatusCode(response.Status, response);
        }


    }
}