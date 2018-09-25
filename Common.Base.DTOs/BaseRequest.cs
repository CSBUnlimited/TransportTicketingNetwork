using System;

namespace Common.Base.DTOs
{
    public abstract class BaseRequest
    {
        public DateTime RequestedDateTime { get; }

        protected BaseRequest()
        {
            RequestedDateTime = DateTime.UtcNow;
        }
    }
}
