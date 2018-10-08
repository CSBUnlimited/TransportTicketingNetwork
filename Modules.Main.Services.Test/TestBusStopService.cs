using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modules.Main.Core.Services;
using Modules.Main.DTOs.BusStop;
using Modules.Main.ViewModels;
using Modules.Main.WebAPI.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Services.Test
{
    public class TestBusStopService
    {
        private readonly Mock<IBusStopService> _busstopService = new Mock<IBusStopService>();

        public TestBusStopService()
        {

        }

        public void BusStopService_AddBusStop_Success_Test()
        {

            // Expected results
            const string expectedresult = "authentication.token.code";
            // Mock input data
            BusStopViewModel busstopViewModel = new BusStopViewModel()
            {
                
                Id = "B001",
                BusStopName = "Galle"
            };
            // Mock output data
            const string output = "authentication.token.code";
            // Data setup for the response
            _busstopService.Setup(us => us.AddBusStop(busstopViewModel)).ReturnsAsync(busstopViewModel);

            // Execute the controller
            BusStopController controller = new BusStopController(_busstopService.Object);

            // Actual result
            Task<IActionResult> result = controller.AddBusStop(new BusStopRequest());
            IActionResult actualResult = result.Result;

            // Asserts
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedresult, actualResult);


        }


    }
}
