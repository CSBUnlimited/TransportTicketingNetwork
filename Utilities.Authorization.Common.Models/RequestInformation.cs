using System.Security.Claims;
using Common.Configurations.Constants;
using Microsoft.AspNetCore.Http;

namespace Utilities.Authorization.Common.Models
{
    public class RequestInformation
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// To get the Token session hash
        /// </summary>
        public string SessionHash => _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        /// <summary>
        /// To get the Token issued time
        /// </summary>
        public string TokenIssueAt => _httpContextAccessor?.HttpContext?.User?.FindFirst(TokenClaimTypes.IssuedAt)?.Value;
        /// <summary>
        /// To get the Token expire time
        /// </summary>
        public string TokenExpireAt => _httpContextAccessor?.HttpContext?.User?.FindFirst(TokenClaimTypes.ExpireAt)?.Value;

        /// <summary>
        /// To get Request user's username
        /// </summary>
        public string RequestedUsername => _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
        /// <summary>
        /// To get Request user's first name
        /// </summary>
        public string RequestedUserFirstName => _httpContextAccessor?.HttpContext?.User?.FindFirst(TokenClaimTypes.FirstName)?.Value;
        /// <summary>
        /// To get Request user's last name
        /// </summary>
        public string RequestedUserLastName => _httpContextAccessor?.HttpContext?.User?.FindFirst(TokenClaimTypes.LastName)?.Value;
        /// <summary>
        /// To get Request user's gender
        /// </summary>
        public string RequestedUserGender => _httpContextAccessor?.HttpContext?.User?.FindFirst(TokenClaimTypes.Gender)?.Value;

        /// <summary>
        /// Get Requested user's IP address
        /// </summary>
        public string RequestedIpAddress => _httpContextAccessor?.HttpContext?.Connection?.LocalIpAddress?.ToString();


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        public RequestInformation(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
