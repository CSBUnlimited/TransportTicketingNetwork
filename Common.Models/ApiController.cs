using System.Collections.Generic;

namespace Common.Models
{
    public class ApiController
    {
        public int Id { get; set; }
        public string ControllerName { get; set; }
        public ModuleEnum ModuleEnum { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<UserRoleApiController> UserRoleApiControllers { get; set; }
        public IEnumerable<ApiFunction> ApiFunctions { get; set; }

        public ApiController()
        {
            ApiFunctions = new HashSet<ApiFunction>();
            UserRoleApiControllers = new HashSet<UserRoleApiController>();
        }
    }
}
