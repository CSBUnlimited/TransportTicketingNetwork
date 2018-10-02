namespace Utilities.Authorization.Common.Models
{
    public interface IRequestInformation
    {
        /// <summary>
        /// To get the Token session hash
        /// </summary>
        string SessionHash { get; }
        /// <summary>
        /// To get the Token issued time
        /// </summary>
        string TokenIssueAt { get; }
        /// <summary>
        /// To get the Token expire time
        /// </summary>
        string TokenExpireAt { get; }

        /// <summary>
        /// To get Request user's username
        /// </summary>
        string RequestedUsername { get; }
        /// <summary>
        /// To get Request user's first name
        /// </summary>
        string RequestedUserFirstName { get; }
        /// <summary>
        /// To get Request user's last name
        /// </summary>
        string RequestedUserLastName { get; }
        /// <summary>
        /// To get Request user's gender
        /// </summary>
        string RequestedUserGender { get; }

        /// <summary>
        /// Get Requested user's IP address
        /// </summary>
        string RequestedIpAddress { get; }

    }
}
