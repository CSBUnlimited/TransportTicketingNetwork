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
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusStopController : Controller
    {
        private readonly IBusStopService _services;
        public BusStopController(IBusStopService services) {

            _services = services;
        }

        //Post Request For Add BusStop
        [HttpPost]
        public ActionResult<BusStop> AddBusStop(BusStop busstops)
        {
            var busstop = _services.AddBusStop(busstops);
            if (busstop==null) {

                return NotFound();
            }
            return busstop;
        }
    }
}
