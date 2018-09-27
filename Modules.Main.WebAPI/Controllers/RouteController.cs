using System;
using System.Collections.Generic;
using System.Linq;
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

    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableActivityLog]
    public class RouteController : Controller
    {

        private readonly ILogger<RouteController> _logger;
        private readonly IRouteService _services;

        public RouteController(ILogger<RouteController> logger,IRouteService services) {
            _logger = logger;
            _services = services;
        }
        
        //Post Request For Add Route
        [HttpPost]
        public async Task<IActionResult> AddRoute(RouteRequest routeRequest)
        {
            RouteResponse response = new RouteResponse();
            

            try
            {
                response.RouteViewModels = new List<RouteViewModel>()
                {
                    await _services.AddRoute(routeRequest.RouteViewModel)
                };

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {

                throw new GlobalException(ex, response);
            }

            return StatusCode(response.Status,response);
        }
    }
}
