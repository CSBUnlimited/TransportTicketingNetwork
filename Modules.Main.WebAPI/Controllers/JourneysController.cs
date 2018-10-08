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
    /// <summary>
    /// This is for Journey Addition
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JourneysController : ControllerBase
    {
        private readonly ILogger<JourneysController> _logger;
        private readonly IJourneyService _journeyService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service"></param>
        public JourneysController(ILogger<JourneysController> logger, IJourneyService service)
        {
            _journeyService = service;
            _logger = logger;
        }
        /// <summary>
        /// This is for get the journey locations
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetJourneyList")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetJourneyList()
        {
            JourneyResponse response = new JourneyResponse();

            try
            {
                response.JourneyViewModels = await _journeyService.GetJourneyListAsync();
                response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                // This line will throw a ArgumentException
                throw new ArgumentException("This is a test Argument Exception.", ex);
            }
            
            return StatusCode(response.Status, response);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="journeyRequest"></param>
        /// <returns></returns>
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