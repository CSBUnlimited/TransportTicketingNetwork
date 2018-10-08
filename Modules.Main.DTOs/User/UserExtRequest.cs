using Common.Base.DTOs;
using Modules.Main.ViewModels;

namespace Modules.Main.DTOs.User
{
    public class UserExtRequest : BaseRequest
    {
        public UserExtViewModel UserExtViewModel { get; set; }
    }
}
