using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.Route;
using Modules.Main.ViewModels;
using Modules.Main.WebAPI.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Services.Test
{
    [TestClass]
    public class TestRouteService
    {

        private readonly Mock<IRouteService> _routeService = new Mock<IRouteService>();

        public TestRouteService() {


        }
        /// <summary>
        /// Test Method.
        /// Test RouteService's AddRoute Method - Success criteria.
        /// </summary>
        [TestMethod]
        public void RouteService_AddRoute_Success_Test()
        {

            // Expected results
            const string expectedresult = "authentication.token.code";
            // Mock input data
            RouteViewModel routeViewModel = new RouteViewModel()
            {
               Id=12,
               Distance=1500

            };
            // Mock output data
            const string output = "authentication.token.code";
            // Data setup for the response
            _routeService.Setup(us => us.AddRoute(routeViewModel)).ReturnsAsync(routeViewModel);

            // Execute the controller
            RouteController controller = new RouteController(_routeService.Object);

            // Actual result
            Task<IActionResult> result = controller.AddRoute(new RouteRequest());
            IActionResult actualResult = result.Result;

            // Asserts
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedresult, actualResult);


        }
    }
}
