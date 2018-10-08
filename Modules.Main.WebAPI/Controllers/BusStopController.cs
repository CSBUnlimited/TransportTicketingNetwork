using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.BusStop;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Utilities.Exception.Models;

namespace Modules.Main.WebAPI.Controllers
{   /// <summary>
    /// BusStop Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusStopController : ControllerBase
    {
        private readonly ILogger<BusStopController> _logger;
        private readonly IBusStopService _busstopService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="busstopService"></param>
        public BusStopController(IBusStopService busstopService) {
            _busstopService = busstopService;

        }

        /// <summary>
        /// BusStop Async
        /// </summary>
        /// <param name="busStopRequest"></param>
        /// <returns></returns>
        [HttpPost("AddBusStop")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddBusStop([FromBody]BusStopRequest busStopRequest)
        {
            BusStopResponse response = new BusStopResponse();


            try
            {
                response.BusStopViewModels = new List<BusStopViewModel>()
                {
                    await _busstopService.AddBusStop(busStopRequest.BusStopViewModel)
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
