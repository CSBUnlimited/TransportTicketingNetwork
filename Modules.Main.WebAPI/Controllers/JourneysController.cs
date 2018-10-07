using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.Journey;
using Modules.Main.ViewModels;
using Utilities.Exception.Models;



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

        [HttpPost("AddJourney")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddJourney([FromBody]JourneyRequest journeyRequest)
        {
            JourneyResponse response = new JourneyResponse();


            try
            {
                response.JourneyViewModels = new List<JourneyViewModel>()
                {
                    await _journeyService.AddJourney(journeyRequest.JourneyViewModel)
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