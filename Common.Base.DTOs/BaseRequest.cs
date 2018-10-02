using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

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
