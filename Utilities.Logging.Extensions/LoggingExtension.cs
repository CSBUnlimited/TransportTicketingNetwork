using System.Collections;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog.Context;
using Formatting = Newtonsoft.Json.Formatting;

namespace Utilities.Logging.Extensions
{
    public static class LoggingExtension
    {
        /// <summary>
        /// Extension method for log activity as information
        /// </summary>
        /// <param name="logger">Serilog's ILogger interface</param>
        /// <param name="message">Activity message</param>
        public static void Activity(this Serilog.ILogger logger, string message)
        {
            logger.Information("{Activity}", message);
        }

        /// <summary>
        /// Extension method for log activity as information
        /// </summary>
        /// <param name="logger">Serilog's ILogger interface</param>
        /// <param name="message">Activity message</param>
        /// <param name="obj">Object than need to append</param>
        public static void Activity(this Serilog.ILogger logger, string message, object obj)
        {
            SetExchange("CustomActivity");
            logger.Information("{CustomActivity}", message, JsonConvert.SerializeObject(obj, Formatting.None));
        }

        public static void Exception(this Serilog.ILogger logger, System.Exception ex)
        {
            SetExchange("Exception");
            logger.Error("{Exception:l} {Message} {ExceptionSource} {ExceptionData} {StackTrace}", true, ex.Message, ex.Source, JsonConvert.SerializeObject(ex.Data), ex.StackTrace);
        }

        /// <summary>
        /// Extension method for Log Exception using 
        /// </summary>
        /// <param name="logger">Serilog's ILogger interface</param>
        /// <param name="message"></param>
        /// <param name="ExceptionSource"></param>
        /// <param name="ExceptionData"></param>
        /// <param name="StackTrace"></param>
        public static void Exception(this Serilog.ILogger logger, string message, string ExceptionSource, IDictionary ExceptionData, string StackTrace)
        {
            logger.Error("{Exception:l} {Message} {ExceptionSource} {ExceptionData} {StackTrace}", true, message, ExceptionSource, JsonConvert.SerializeObject(ExceptionData), StackTrace);
        }

        public static void Exception(this ILogger logger, string message, string ExceptionSource, IDictionary ExceptionData, string StackTrace)
        {
            logger.LogError("{Exception:l} {Message} {ExceptionSource} {ExceptionData} {StackTrace}", true, message, ExceptionSource, JsonConvert.SerializeObject(ExceptionData), StackTrace);
        }

        private static void SetExchange(string exchange)
        {
            LogContext.PushProperty("Exchange", exchange);
        }
    }
}
