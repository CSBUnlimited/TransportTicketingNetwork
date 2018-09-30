using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.Route;
using Modules.Main.Models;
using Modules.Main.ViewModels;
using Utilities.Exception.Models;
using Utilities.Logging.Common.Attributes;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Modules.Main.WebAPI.Controllers
{
    /// <summary>
    /// Route Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableActivityLog]
    public class RouteController : ControllerBase
    {

        private readonly ILogger<RouteController> _logger;
        private readonly IRouteService _routeService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        /// <param name="routeService">Route Service</param>
        public RouteController(ILogger<RouteController> logger,IRouteService routeService) {
            _logger = logger;
            _routeService = routeService;
        }
        
       /// <summary>
       /// Route Async
       /// </summary>
       /// <param name="routeRequest">FromBody-RouteRequest</param>
       /// <returns>RouteResponse</returns>
       
        [HttpPost("AddRoute")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [EnableActivityLog]
        public async Task<IActionResult> AddRoute([FromBody]RouteRequest routeRequest)
        {
            RouteResponse response = new RouteResponse();
            

            try
            {
                response.RouteViewModels = new List<RouteViewModel>()
                {
                    await _routeService.AddRoute(routeRequest.RouteViewModel)
                };

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {

                throw new GlobalException(ex, response);
            }

            return StatusCode(response.Status,response);
        }

        /// <summary>
        /// Getting Route
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        [HttpGet(Name = "GetRouteList")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [EnableActivityLog]

        public async Task<IActionResult> GetRouteList()
        {
            RouteResponse response = new RouteResponse();

            try
            {
                response.RouteViewModels = await _routeService.GetRouteListAsync();
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
