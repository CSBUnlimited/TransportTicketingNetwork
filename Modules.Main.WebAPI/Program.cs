using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Modules.Main.WebAPI
{
    /// <summary>
    /// Program Class - First class that calls when app started
    /// </summary>
    public class Program
    {
        /// <summary>
        /// First method calls when app started
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creating the Web Host
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
