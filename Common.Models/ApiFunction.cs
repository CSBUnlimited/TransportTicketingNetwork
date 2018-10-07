using System.Collections.Generic;

namespace Common.Models
{
    public class ApiFunction
    {
        public int Id { get; set; }
        public string FunctionName { get; set; }
        public bool IsActive { get; set; }

        public int ApiControllerId { get; set; }
        public ApiController ApiController { get; set; }

        public IEnumerable<UserRoleApiFunction> UserRoleApiFunctions { get; set; }

        public ApiFunction()
        {
            UserRoleApiFunctions = new HashSet<UserRoleApiFunction>();
        }
    }
}
