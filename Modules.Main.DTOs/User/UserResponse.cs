using Common.Base.DTOs;
using Modules.Main.ViewModels;

namespace Modules.Main.DTOs.User
{
    public class UserResponse : BaseResponse
    {
        public UserViewModel UserViewModel { get; set; }
    }
}
