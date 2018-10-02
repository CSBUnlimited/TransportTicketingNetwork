using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modules.Main.ViewModels;
using Moq;
using Utilities.Authorization.Core.Services;

namespace Modules.Main.Services.Test
{
    [TestClass]
    public class TestAuthorizationService
    {
        #region Declarations
        
        private readonly Mock<IAuthorizationService> _authorizationService = new Mock<IAuthorizationService>();

        #endregion

        /// <summary>
        /// Test Method.
        /// Test AuthorizationService's UserLoginAsync Method - Success criteria.
        /// </summary>
        [TestMethod]
        public void AuthorizationService_UserLoginAsync_Success_Test()
        {
            // Expected results
            const string expectedAuthToken = "authentication.token.code";

            // Mock input data
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                Username = "Test-Username",
                Password = "Test-Password"
            };

            // Mock output data
            const string authToken = "authentication.token.code";

            // Data setup for the response 
            _authorizationService.Setup(us => us.AuthenticateLoginAsync(loginViewModel.Username, loginViewModel.Password)).ReturnsAsync(authToken);

            // Execute the service
            AuthorizationService authorizationService = new AuthorizationService(_authorizationService.Object);
            
            // Actual result
            Task<string> result = authorizationService.UserLoginAsync(loginViewModel);
            string actualResult = result.Result;

            // Asserts
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedAuthToken, actualResult);
        }

        /// <summary>
        /// Test Method.
        /// Test AuthorizationService's RenewAuthenticationTokenAsync Method - Success criteria.
        /// </summary>
        [TestMethod] 
        public void AuthorizationService_RenewAuthenticationTokenAsync_Success_Test()
        {
            // Expected results
            const string expectedAuthToken = "authentication.token.code";

            // Mock output data
            const string authToken = "authentication.token.code";

            // Data setup for the response 
            _authorizationService.Setup(us => us.RenewAuthenticateTokenAndExpireOldTokenAsync()).ReturnsAsync(authToken);

            // Execute the service
            AuthorizationService authorizationService = new AuthorizationService(_authorizationService.Object);

            // Actual result
            Task<string> result = authorizationService.RenewAuthenticationTokenAsync();
            string actualResult = result.Result;

            // Asserts
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedAuthToken, actualResult);
        }

        /// <summary>
        /// Test Method.
        /// Test AuthorizationService's LogoutUserAsync Method - Success criteria.
        /// </summary>
        [TestMethod]
        public void AuthorizationService_LogoutUserAsync_Success_Test()
        {
            // Data setup for the response 
            _authorizationService.Setup(us => us.LogoutUserAsync()).Returns(Task.CompletedTask);

            // Execute the service
            AuthorizationService authorizationService = new AuthorizationService(_authorizationService.Object);

            // Actual result
            Task result = authorizationService.UserLogoutAsync();

            // Asserts
            Assert.IsTrue(result.IsCompleted);
            Assert.IsFalse(result.IsFaulted);
        }
    }
}
