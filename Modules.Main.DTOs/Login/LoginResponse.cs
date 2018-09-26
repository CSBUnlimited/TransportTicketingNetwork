using System;
using System.Collections.Generic;
using System.Text;
using Common.Base.DTOs;

namespace Modules.Main.DTOs.Login
{
    public class LoginResponse : BaseResponse
    {
        public string AuthenticationToken { get; set; }
    }
}
