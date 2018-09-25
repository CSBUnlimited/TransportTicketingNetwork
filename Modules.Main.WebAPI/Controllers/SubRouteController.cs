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
    [Route("subroute/")]
    [ApiController]
    public class SubRouteController : Controller
    {
        private readonly ISubRouteService _services;

        public SubRouteController(ISubRouteService services) {

            _services = services;
        }
        // GET: /<controller>/
        [HttpPost]
        public ActionResult<SubRoute> AddSubRoute(SubRoute subroutes)
        {
            var subroute = _services.AddSubRoute(subroutes);
            if (subroute==null) {
                return NotFound();
            }
            
            return subroute;
        }
    }
}
