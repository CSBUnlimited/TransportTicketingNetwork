using System;
using System.Collections.Generic;

namespace Modules.Main.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime EffectiveDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }

        public User User { get; set; }

        public IEnumerable<ApplicationUserToken> ApplicationUserTokens { get; set; }

        public ApplicationUser()
        {
            ApplicationUserTokens = new HashSet<ApplicationUserToken>();
        }
    }
}
