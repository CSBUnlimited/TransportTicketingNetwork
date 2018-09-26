using Common.Base.DTOs;
using Modules.Main.ViewModels;

namespace Modules.Main.DTOs.Login
{
    public class LoginRequest : BaseRequest
    {
        public LoginViewModel LoginViewModel { get; set; }
    }
}
