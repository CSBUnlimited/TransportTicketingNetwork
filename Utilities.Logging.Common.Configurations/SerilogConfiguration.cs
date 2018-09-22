using Microsoft.Extensions.Configuration;
using Serilog;

namespace Utilities.Logging.Common.Configurations
{
    public static class SerilogConfiguration
    {
        public static ILogger ConfigureSerilog(this LoggerConfiguration loggerConfiguration, IConfiguration configuration)
        {
            return loggerConfiguration
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
