using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modules.Main.Core.Services;
using Modules.Main.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Modules.Main.WebAPI.Controllers
{
    [Route("route/")]
    [ApiController]
    public class RouteController : Controller
    {
        private readonly IRouteService _services;

        public RouteController(IRouteService services) {
            _services = services;
        }
        // GET: /<controller>/

        [HttpPost]
        public ActionResult<Route> AddRoute(Route routes)
        {
            var route = _services.AddRoute(routes);
            if (route == null)
            {
                return NotFound();
            }
           
            return route;
        }
    }
}
