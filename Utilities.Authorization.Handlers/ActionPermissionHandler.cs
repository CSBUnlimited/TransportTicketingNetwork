using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Configurations.Constants;
using Microsoft.AspNetCore.Authorization;
using CoreServices = Utilities.Authorization.Core.Services;

namespace Utilities.Authorization.Handlers
{
    /// <summary>
    /// Authorization Permission Handler
    /// </summary>
    public class ActionPermissionHandler : AuthorizationHandler<ActionPermissionRequirement>
    {
        private readonly CoreServices.IAuthorizationService _authorizationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authorizationService">Authorization Service</param>
        public ActionPermissionHandler(CoreServices.IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ActionPermissionRequirement requirement)
        {
            // Check username and session hash is in the token
            if (!(context.User?.HasClaim(c => c.Type == ClaimTypes.Name) == true &&
                  context.User?.HasClaim(c => c.Type == ClaimTypes.NameIdentifier) == true))
            {
                context.Fail();
                return;
            }

            // Convert expire and issue dates
            if (!(DateTime.TryParse(context.User?.FindFirst(TokenClaimTypes.IssuedAt)?.Value,
                      out DateTime issuedAtDateTime) |
                  DateTime.TryParse(context.User?.FindFirst(TokenClaimTypes.ExpireAt)?.Value,
                      out DateTime expireAtDateTime)))
            {
                context.Fail();
                return;
            }

            // Check datetime now between issued and expire datetime
            if (!(issuedAtDateTime <= DateTime.Now && expireAtDateTime > DateTime.Now))
            {
                context.Fail();
                return;
            }

            string username = context.User?.FindFirst(ClaimTypes.Name).Value;
            string sessionHash = context.User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Check whether user is authorized to do this process
            if (!await _authorizationService.IsUserAuthorizedAsync(username, sessionHash))
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}
