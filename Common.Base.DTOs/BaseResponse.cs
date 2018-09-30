using System;

namespace Common.Base.DTOs
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }

        private int _status;
        public int Status
        {
            get
            {
                if (_status == 0 && IsSuccess)
                {
                    _status = 200;
                }

                return _status;
            }
            set => _status = value;
        }

        public string RequestedUsername { get; set; }
        public DateTime RespondedDateTime { get; }
        public string Message { get; set; }
        public string MessageDetails { get; set; }

        public BaseResponse()
        {
            RespondedDateTime = DateTime.UtcNow;
        }
    }
}
