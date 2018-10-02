using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.Journey;

namespace Modules.Main.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JourneysController : ControllerBase
    {
        private readonly ILogger<JourneysController> _logger;
        private readonly IJourneyService _journeyService;

        public JourneysController(IJourneyService service)
        {
            _journeyService = service;
        }
        /// <summary>
        /// This is for get the journey locations
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetJourneyLocation")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetJourneyLocation()
        {
            JourneyResponse response = new JourneyResponse();
            
            return StatusCode(response.Status, response);
        }

    }
}