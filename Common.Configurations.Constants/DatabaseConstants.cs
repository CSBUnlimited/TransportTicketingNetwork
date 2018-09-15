using System;

namespace Common.Configurations.Constants
{
    public static class DatabaseConstants
    {
        public static DateTime ExpireUtcDateTime { get; } = new DateTime(2080, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static string ExpireUtcDateTimeValueSql { get; } = "GETUTCDATE()";

        public static DateTime CurrentUtcDateTime => DateTime.UtcNow;
        public static string CurrentUtcDateTimeValueSql { get; } = "'2080-01-01'";
    }
}
