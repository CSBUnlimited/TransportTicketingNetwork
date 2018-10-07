using Common.Models;
using System.Collections.Generic;

namespace Modules.Main.Models
{
    public class UserExt : User
    {
        public IEnumerable<Payment> ApprovedPayments { get; set; }
        public IEnumerable<Payment> Payments { get; set; }

        public UserExt()
        {
            ApprovedPayments = new HashSet<Payment>();
            Payments = new HashSet<Payment>();
        }
    }
}
