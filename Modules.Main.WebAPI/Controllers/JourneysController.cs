using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.Journey;
using Modules.Main.DTOs.TestLog;
using Utilities.Logging.Common.Attributes;

namespace Modules.Main.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableActivityLog]
    public class JourneysController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
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
        [EnableActivityLog]
        public IActionResult GetJourneyLocation()
        {
            JourneyResponse response = new JourneyResponse();
            
            return StatusCode(response.Status, response);
        }

    }
}