using Common.Base.DTOs;
using Modules.Main.ViewModels;

namespace Modules.Main.DTOs.User
{
    public class UserRequest : BaseRequest
    {
        public UserViewModel UserViewModel { get; set; }
    }
}
