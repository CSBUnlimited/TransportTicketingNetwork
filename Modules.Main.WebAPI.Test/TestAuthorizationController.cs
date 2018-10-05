using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.Extensions.Logging;
using Modules.Main.WebAPI.Controllers;
using Modules.Main.Core.Services;
using Modules.Main.ViewModels;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Modules.Main.DTOs.Login;
using System.Threading.Tasks;
using Common.Base.DTOs;
using FluentValidation;
using Utilities.Exception.Models;

namespace Modules.Main.WebAPI.Test
{
    /// <summary>
    /// Test Class.
    /// Test for AuthorizationController.
    /// </summary>
    [TestClass]
    [SuppressMessage("ReSharper", "UnusedVariable")]
    public class TestAuthorizationController
    {
        #region Declarations

        private readonly Mock<ILogger<AuthorizationController>> _logger = new Mock<ILogger<AuthorizationController>>();
        private readonly Mock<IAuthorizationService> _userService = new Mock<IAuthorizationService>();

        #endregion

        /// <summary>
        /// Test Method.
        /// Test AuthorizationController's LoginUserAsync Action - Success criteria
        /// </summary>
        [TestMethod]
        public void AuthorizationController_LoginUserAsync_Success_Test()
        {
            // Expected results
            const int expectedStatusCode = (int)HttpStatusCode.OK;

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
            const string authToken = "authentication.token.code";

            // Data setup for the response 
            _userService.Setup(us => us.UserLoginAsync(loginViewModel)).ReturnsAsync(authToken);

            // Execute the controller
            AuthorizationController authorizationController = new AuthorizationController(_logger.Object, _userService.Object);
            Task<IActionResult> response = authorizationController.LoginUserAsync(loginRequest);

            // Action Result
            IActionResult actionResult = response.Result;

            // Cast Action Result to OkObject
            ObjectResult objectResult = actionResult as ObjectResult;
            Assert.IsNotNull(objectResult);
            Assert.AreEqual(expectedStatusCode, objectResult.StatusCode);

            // Get the response
            LoginResponse loginResponse = objectResult.Value as LoginResponse;
            Assert.IsNotNull(loginResponse);
            Assert.IsTrue(loginResponse.IsSuccess);
            Assert.AreEqual(expectedStatusCode, loginResponse.Status);
            Assert.AreEqual(authToken, loginResponse.AuthenticationToken);
        }

        /// <summary>
        /// Test Method.
        /// Test AuthorizationController's LoginUserAsync Action - Failure criteria 1.
        /// Service will throw exception in this test case
        /// </summary>
        [TestMethod]
        public void AuthorizationController_LoginUserAsync_Failure_Test_1()
        {
            // Exception message
            const string exceptionMessage = "Invalid Username or Password.";

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

            // Data setup for the response 
            _userService.Setup(us => us.UserLoginAsync(loginViewModel)).ThrowsAsync(new Exception(exceptionMessage));

            // Execute the controller
            AuthorizationController authorizationController = new AuthorizationController(_logger.Object, _userService.Object);
            Task<IActionResult> response = authorizationController.LoginUserAsync(loginRequest);

            // Action Result
            try
            {
                IActionResult actionResult = response.Result;
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.InnerException);
                Assert.ThrowsException<GlobalException>(() => throw ex.InnerException, "Expected GlobalException but something else thrown.");

                Assert.IsNotNull(ex.InnerException.InnerException);
                Assert.AreEqual(exceptionMessage, ex.InnerException.InnerException.Message);

                return;
            }
            
            Assert.Fail("Expected exception but no exception was thrown.");
        }

        /// <summary>
        /// Test Method.
        /// Test AuthorizationController's LoginUserAsync Action - Failure criteria 2.
        /// Controller will throw an Validation Exception.
        /// </summary>
        [TestMethod]
        public void AuthorizationController_LoginUserAsync_FailureTest_2()
        {
            // Exception message
            const string exceptionMessage = "Invalid Username or Password.";

            // Mock input data
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                Username = "*Invalid-Username",
                Password = "Test-Password"
            };

            LoginRequest loginRequest = new LoginRequest()
            {
                LoginViewModel = loginViewModel
            };

            // Data setup for the response 
            _userService.Setup(us => us.UserLoginAsync(loginViewModel)).ReturnsAsync("auth-token");

            // Execute the controller
            AuthorizationController authorizationController = new AuthorizationController(_logger.Object, _userService.Object);
            Task<IActionResult> response = authorizationController.LoginUserAsync(loginRequest);

            // Action Result
            try
            {
                IActionResult actionResult = response.Result;
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.InnerException);
                Assert.ThrowsException<GlobalException>(() => throw ex.InnerException, "Expected GlobalException but something else thrown.");

                Assert.IsNotNull(ex.InnerException.InnerException);
                Assert.ThrowsException<ValidationException>(() => throw ex.InnerException.InnerException, "Expected ValidationException but something else thrown.");
                Assert.AreEqual(exceptionMessage, ex.InnerException.InnerException.Message);

                return;
            }

            Assert.Fail("Expected exception but no exception was thrown.");
        }

        /// <summary>
        /// Test Method.
        /// Test AuthorizationController's LogoutUserAsync Action - Success criteria
        /// </summary>
        [TestMethod]
        public void AuthorizationController_LogoutUserAsync_Success_Test()
        {
            // Expected results
            const int expectedStatusCode = (int)HttpStatusCode.OK;

            // Data setup for the response
            _userService.Setup(us => us.UserLogoutAsync()).Returns(Task.CompletedTask);

            // Execute the controller
            AuthorizationController authorizationController = new AuthorizationController(_logger.Object, _userService.Object);
            Task<IActionResult> response = authorizationController.LogoutUserAsync();

            // Action Result
            IActionResult actionResult = response.Result;

            // Cast Action Result to OkObject
            ObjectResult objectResult = actionResult as ObjectResult;
            Assert.IsNotNull(objectResult);
            Assert.AreEqual(expectedStatusCode, objectResult.StatusCode);

            // Get the response
            BaseResponse logoutResponse = objectResult.Value as BaseResponse;
            Assert.IsNotNull(logoutResponse);
            Assert.IsTrue(logoutResponse.IsSuccess);
            Assert.AreEqual(expectedStatusCode, logoutResponse.Status);
        }

        /// <summary>
        /// Test Method.
        /// Test AuthorizationController's LogoutUserAsync Action - Failure criteria.
        /// Service will throw exception in this test case
        /// </summary>
        [TestMethod]
        public void AuthorizationController_LogoutUserAsync_Failure_Test()
        {
            // Exception message
            const string exceptionMessage = "User not logged in correctly.";

            // Data setup for the response 
            _userService.Setup(us => us.UserLogoutAsync()).ThrowsAsync(new Exception(exceptionMessage));

            // Execute the controller
            AuthorizationController authorizationController = new AuthorizationController(_logger.Object, _userService.Object);
            Task<IActionResult> response = authorizationController.LogoutUserAsync();

            // Action Result
            try
            {
                IActionResult actionResult = response.Result;
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.InnerException);
                Assert.ThrowsException<GlobalException>(() => throw ex.InnerException, "Expected GlobalException but something else thrown.");

                Assert.IsNotNull(ex.InnerException.InnerException);
                Assert.AreEqual(exceptionMessage, ex.InnerException.InnerException.Message);

                return;
            }

            Assert.Fail("Expected exception but no exception was thrown.");
        }

        /// <summary>
        /// Test Method.
        /// Test AuthorizationController's RenewAuthenticationTokenAsync Action - Success criteria
        /// </summary>
        [TestMethod]
        public void AuthorizationController_RenewAuthenticationTokenAsync_Success_Test()
        {
            // Expected results
            const int expectedStatusCode = (int)HttpStatusCode.OK;

            // Mock output data
            const string authToken = "new.authentication.token.code";
            
            // Data setup for the response
            _userService.Setup(us => us.RenewAuthenticationTokenAsync()).ReturnsAsync(authToken);

            // Execute the controller
            AuthorizationController authorizationController = new AuthorizationController(_logger.Object, _userService.Object);
            Task<IActionResult> response = authorizationController.RenewAuthenticationTokenAsync();

            // Action Result
            IActionResult actionResult = response.Result;

            // Cast Action Result to OkObject
            ObjectResult objectResult = actionResult as ObjectResult;
            Assert.IsNotNull(objectResult);
            Assert.AreEqual(expectedStatusCode, objectResult.StatusCode);

            // Get the response
            LoginResponse loginResponse = objectResult.Value as LoginResponse;
            Assert.IsNotNull(loginResponse);
            Assert.IsTrue(loginResponse.IsSuccess);
            Assert.AreEqual(expectedStatusCode, loginResponse.Status);
            Assert.AreEqual(authToken, loginResponse.AuthenticationToken);
        }

        /// <summary>
        /// Test Method.
        /// Test AuthorizationController's RenewAuthenticationTokenAsync Action - Failure criteria.
        /// Service will throw exception in this test case
        /// </summary>
        [TestMethod]
        public void AuthorizationController_RenewAuthenticationTokenAsync_Failure_Test()
        {
            // Exception message
            const string exceptionMessage = "User not logged in correctly.";

            // Data setup for the response 
            _userService.Setup(us => us.RenewAuthenticationTokenAsync()).ThrowsAsync(new Exception(exceptionMessage));

            // Execute the controller
            AuthorizationController authorizationController = new AuthorizationController(_logger.Object, _userService.Object);
            Task<IActionResult> response = authorizationController.RenewAuthenticationTokenAsync();

            // Action Result
            try
            {
                IActionResult actionResult = response.Result;
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.InnerException);
                Assert.ThrowsException<GlobalException>(() => throw ex.InnerException, "Expected GlobalException but something else thrown.");

                Assert.IsNotNull(ex.InnerException.InnerException);
                Assert.AreEqual(exceptionMessage, ex.InnerException.InnerException.Message);

                return;
            }

            Assert.Fail("Expected exception but no exception was thrown.");
        }
    }
}
