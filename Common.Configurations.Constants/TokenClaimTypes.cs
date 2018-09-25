using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Configurations.Constants
{
    public static class TokenClaimTypes
    {
        public static string FirstName { get; } = "FN";
        public static string LastName { get; } = "LN";
        public static string SessionHash { get; } = "SH";
        public static string Gender { get; } = "GN";
        public static string IssuedAt { get; } = "IA";
        public static string ExpireAt { get; } = "EA";
    }
}
