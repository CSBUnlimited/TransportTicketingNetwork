﻿using System;

namespace Common.Base.DTOs
{
    public class BaseRequest
    {
        public DateTime RequestedDateTime { get; set; }

        public BaseRequest()
        {
            RequestedDateTime = DateTime.UtcNow;
        }
    }
}