using System.Collections.Generic;

namespace Common.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public UserRoleEnum UserRoleEnum { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public IEnumerable<ApiController> ApiControllers { get; set; }
        public IEnumerable<ApiFunction> ApiFunctions { get; set; }

        public UserRole()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
            ApiControllers = new HashSet<ApiController>();
            ApiFunctions = new HashSet<ApiFunction>();
        }
    }
}
