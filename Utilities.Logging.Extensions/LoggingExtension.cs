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
        /// Set a exchange property
        /// </summary>
        /// <param name="exchange"></param>
        private static void SetExchange(string exchange)
        {
            LogContext.PushProperty("Exchange", exchange);
        }

        /// <summary>
        /// Extension method for log activity as information
        /// </summary>
        /// <param name="logger">Serilog's ILogger interface</param>
        public static void Activity(this Serilog.ILogger logger)
        {
            logger.Information("{Activity:l}");
        }

        /// <summary>
        /// Extension method for log activity as information
        /// </summary>
        /// <param name="logger">ILogger interface</param>
        public static void Activity(ILogger logger)
        {
            logger.LogInformation("{Activity:l}");
        }

        /// <summary>
        /// Extension method for log custom activity as information
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
        /// Extension method for Log Exception using Serilog's ILogger interface
        /// Log as Error
        /// </summary>
        /// <param name="logger">Serilog's ILogger interface</param>
        /// <param name="message"></param>
        /// <param name="exceptionSource"></param>
        /// <param name="exceptionData"></param>
        /// <param name="stackTrace"></param>
        public static void Exception(this Serilog.ILogger logger, string message, string exceptionSource, IDictionary exceptionData, string stackTrace)
        {
            logger.Error("{Exception:l} {Message} {ExceptionSource} {ExceptionData} {StackTrace}", true, message, exceptionSource, JsonConvert.SerializeObject(exceptionData), stackTrace);
        }

        /// <summary>
        /// Extension method for Log Exception using Microsoft's ILogger interface
        /// Log as Error
        /// </summary>
        /// <param name="logger">Microsoft's ILogger interface</param>
        /// <param name="message"></param>
        /// <param name="exceptionSource"></param>
        /// <param name="exceptionData"></param>
        /// <param name="stackTrace"></param>
        public static void Exception(this ILogger logger, string message, string exceptionSource, IDictionary exceptionData, string stackTrace)
        {
            logger.LogError("{Exception:l} {Message} {ExceptionSource} {ExceptionData} {StackTrace}", true, message, exceptionSource, JsonConvert.SerializeObject(exceptionData), stackTrace);
        }

        /// <summary>
        /// Extension method for Log Exception using Microsoft's ILogger interface
        /// Use for known or expected exceptions
        /// Log as Warning
        /// </summary>
        /// <param name="logger">Microsoft's ILogger interface</param>
        /// <param name="message"></param>
        /// <param name="exceptionSource"></param>
        /// <param name="exceptionData"></param>
        /// <param name="stackTrace"></param>
        public static void WarningException(this ILogger logger, string message, string exceptionSource, IDictionary exceptionData, string stackTrace)
        {
            logger.LogWarning("{Exception:l} {Message} {ExceptionSource} {ExceptionData} {StackTrace}", true, message, exceptionSource, JsonConvert.SerializeObject(exceptionData), stackTrace);
        }


    }
}
