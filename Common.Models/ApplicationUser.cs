using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime EffectiveDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public bool IsBlocked { get; set; }
        public UserType UserType { get; set; }

        public User User { get; set; }

        public IEnumerable<ApplicationUserToken> ApplicationUserTokens { get; set; }

        public ApplicationUser()
        {
            ApplicationUserTokens = new HashSet<ApplicationUserToken>();
        }
    }

    public enum UserType : byte
    {
        Unknown = 0,
        ForeignCustomer = 1,
        LocalCustomer = 2,
        TransportManager = 5,
        Administrator = 7
    }
}
