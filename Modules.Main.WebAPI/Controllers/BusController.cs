﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.Bus;
using Modules.Main.ViewModels;
using Utilities.Exception.Models;

namespace Modules.Main.WebAPI.Controllers
{
    /// <summary>
    /// Buses Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly ILogger<BusController> _logger;
        private readonly IBusService _busService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger injection</param>
        /// <param name="busService">Bus Service</param>
        public BusController(ILogger<BusController> logger, IBusService busService)
        {
            _logger = logger;
            _busService = busService;
        }



        /// <summary>
        /// Get Bus Async
        /// </summary>
        /// <param name="id">FromRoute- busNumber</param>
        /// <returns>BusResponse</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        [HttpGet("{id}", Name = "GetBus")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBus([FromRoute] string id)
        {
            //Changes - FromRoute  string id ||  [HttpGet("{id}", Name = "GetBus")]  || string busNumber = id; || <param name="id">FromRoute- busNumber</param>
            string busNumber = id;
            BusResponse response = new BusResponse();
            
            try
            {
                response.BusViewModel = await _busService.GetBusAsync(busNumber);
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                // This line will throw a ArgumentException Changes - Add a Valid Exception
                throw new ArgumentException("This is a test Argument Exception.", ex);
            }

            return StatusCode(response.Status, response);
        }



        /// <summary>
        /// Get Bus List Async
        /// Outer exception is an ArgumentException.
        /// </summary>
        /// <returns>BusResponse</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        [HttpGet(Name = "GetBusList")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBusList()
        {
            BusResponse response = new BusResponse();

            try
            {
                response.BusViewModels = await _busService.GetBusListAsync();
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                // This line will throw a ArgumentException
                throw new ArgumentException("This is a test Argument Exception.", ex);
            }

            return StatusCode(response.Status, response);
        }


        /// <summary>
        /// Add Bus - Async
        /// </summary>
        /// <param name="busRequest">FromBody - BusRequest</param>
        /// <returns>BusResponse</returns>
        [HttpPost(Name = "AddBus")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddBus([FromBody]BusRequest busRequest)
        {
            BusResponse response = new BusResponse();

            try
            {

                response.BusViewModels = new List<BusViewModel>();

                {
                    await _busService.AddBusAsync(busRequest.BusViewModel);
                };

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                throw new GlobalException(ex, response);
            }

            return StatusCode(response.Status, response);
        }


        /// <summary>
        /// Delete Bus 
        /// </summary>
        /// <param name="id">FromRoute - busNumber</param>
        /// <returns>BusResponse</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request by client</response>
        [HttpDelete("{id}", Name = "DeleteBus")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteBus([FromRoute] string id)
        {
            //Changes - FromRoute  string id ||  [HttpGet("{id}", Name = "DeleteBus")]  || string busNumber = id;|| <param name="id">FromRoute - busNumber</param>
            string busNumber = id;
            BusResponse response = new BusResponse();

            try
            {
                response.BusViewModel = await _busService.DeleteBus(busNumber);
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                // This line will throw a ArgumentException Changes - Add a Valid Exception
                throw new ArgumentException("This is a test Argument Exception.", ex);
            }

            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Update Bus - Async
        /// </summary>
        /// <param name="id">FromRoute - id</param>
        /// <param name="busRequest">FromBody - Bus Request</param>
        /// <returns>BusResponse</returns>
        [HttpPut(Name = "UpdateBus")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateBus([FromRoute] string id,[FromBody]BusRequest busRequest)
        {
            //Changes - FromRoute  string id ||  [HttpGet("{id}", Name = "DeleteBus")]  || string busNumber = id;
            /*
             /// <param name="id">FromRoute - id</param>
             /// <param name="busRequest">FromBody - Bus Request</param>
             */
            BusResponse response = new BusResponse();

            try
            {

                response.BusViewModels = new List<BusViewModel>();

                {
                    await _busService.AddBusAsync(busRequest.BusViewModel);
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