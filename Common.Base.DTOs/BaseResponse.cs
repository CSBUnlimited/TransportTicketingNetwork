using System;

namespace Common.Base.DTOs
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RespondedDateTime { get; }

        public BaseResponse()
        {
            RespondedDateTime = DateTime.UtcNow;
        }
    }
}
