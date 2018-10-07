using System;

namespace Modules.Main.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string  ReferenceNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime TransactionDateTime { get; set; }

        public int ApprovedUserId { get; set; }
        public UserExt ApprovedUser { get; set; }

        public int UserId { get; set; }
        public UserExt User { get; set; }
    }

    public enum PaymentMethod : byte
    {
        CreditCard = 1,
        Mobile = 2,
        Cash = 3
    }
}
