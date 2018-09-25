using Common.Base.DTOs;

namespace Utilities.Exception.Models
{
    /// <inheritdoc />
    /// <summary>
    /// Global Exception - This is use for handle exceptions globally and return a structured output
    /// </summary>
    public sealed class GlobalException : System.Exception
    {
        /// <summary>
        /// Response that is going to send to client
        /// </summary>
        public BaseResponse Response { get; }

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="innerException">Inner exception that occured</param>
        /// <param name="response">Response that is going to send to client</param>
        public GlobalException(System.Exception innerException, BaseResponse response) : base("", innerException)
        {
            Response = response;
        }
    }
}
