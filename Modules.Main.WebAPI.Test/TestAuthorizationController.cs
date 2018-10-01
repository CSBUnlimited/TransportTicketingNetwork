using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.Extensions.Logging;
using Modules.Main.WebAPI.Controllers;
using Modules.Main.Core.Services;
using Modules.Main.ViewModels;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Modules.Main.DTOs.Login;
using System.Threading.Tasks;

namespace Modules.Main.WebAPI.Test
{
    [TestClass]
    public class TestAuthorizationController
    {
        #region Declarations

        private readonly Mock<ILogger<AuthorizationController>> logger = new Mock<ILogger<AuthorizationController>>();
        private readonly Mock<IUserService> userService = new Mock<IUserService>();

        #endregion

        [TestMethod]
        public void AuthorizationController_LoginUserAsync()
        {
            // Expected results
            int statusCode = (int)HttpStatusCode.OK;
            bool isSuccess = true;

            // Mock input data
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                Username = "Test-Username",
                Password = "Test-Password"
            };

            LoginRequest loginRequest = new LoginRequest()
            {
                LoginViewModel = loginViewModel
            };

            // Mock output data
            string authToken = "authentication.token.code";

            // Data setup for the response 
            userService.Setup(x => x.UserLoginAsync(loginViewModel)).ReturnsAsync(authToken);

            // Execute the controller
            AuthorizationController authorizationController = new AuthorizationController(logger.Object, userService.Object);
            Task<IActionResult> response = authorizationController.LoginUserAsync(loginRequest);

            // Action Result
            IActionResult actionResult = response.Result;

            //actionResult.ExecuteResultAsync().
        }
    }
}
