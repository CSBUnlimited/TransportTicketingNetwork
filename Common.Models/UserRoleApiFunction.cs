using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class UserRoleApiFunction
    {
        public int Id { get; set; }
        public bool IsDenied { get; set; }

        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        public int ApiFunctionId { get; set; }
        public ApiFunction ApiFunction { get; set; }

        public bool IsActive { get; set; }
    }
}
