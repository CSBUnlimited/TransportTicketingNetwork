using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    public class ApplicationUserToken
    {
        public int Id { get; set; }
        public string TokenHash { get; set; }
        public DateTime EffectiveDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}