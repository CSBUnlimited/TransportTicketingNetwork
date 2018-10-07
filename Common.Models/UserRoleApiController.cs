namespace Common.Models
{
    public class UserRoleApiController
    {
        public int Id { get; set; }

        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        public int ApiControllerId { get; set; }
        public ApiController ApiController { get; set; }

        public bool IsActive { get; set; }
    }
}
