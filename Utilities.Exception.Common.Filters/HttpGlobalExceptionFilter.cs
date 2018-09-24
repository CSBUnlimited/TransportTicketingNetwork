using System.Net;
using Common.Base.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog.Context;
using Utilities.Exception.Models;
using Utilities.Logging.Extensions;

namespace Utilities.Exception.Common.Filters
{
    /// <summary>
    /// This filter handle exceptions globally
    /// </summary>
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Create basic things that need to be log
        /// </summary>
        /// <param name="context">Exception Context</param>
        private static void CreateLogBaseContext(ExceptionContext context)
        {
            LogContext.PushProperty("Controller", context.RouteData.Values["controller"]);
            LogContext.PushProperty("Action", context.RouteData.Values["action"]);
            LogContext.PushProperty("RequestPath", context.HttpContext.Request.Path);
        }

        /// <summary>
        /// Create basic things that need to be log
        /// </summary>
        /// <param name="context">Exception Context</param>
        /// <param name="isImmediate">Is immediately want ot log. If true, Exchange will not set</param>
        private void WriteExceptionLog(ExceptionContext context, bool isImmediate = false)
        {
            if (!isImmediate)
            {
                switch (context.Exception)
                {
                    // Check is this a Validation Exception
                    case ValidationException _:
                        LogContext.PushProperty("Exchange", "ValidationError");
                        _logger.WarningException(context.Exception.Message, context.Exception.Source, context.Exception.Data, context.Exception.StackTrace);
                        break;
                    default:
                        LogContext.PushProperty("Exchange", "Exception");
                        _logger.Exception(context.Exception.Message, context.Exception.Source, context.Exception.Data, context.Exception.StackTrace);
                        break;
                }
            }
            else
            {
                _logger.Exception(context.Exception.Message, context.Exception.Source, context.Exception.Data, context.Exception.StackTrace);
            }
        }

        /// <summary>
        /// Create a BadRequest ObjectResult
        /// </summary>
        /// <param name="response">Response</param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static BadRequestObjectResult BuildResponse(BaseResponse response, ExceptionContext context)
        {
            response.IsSuccess = false;
            response.Status = (int)HttpStatusCode.BadRequest;

            switch (context.Exception)
            {
                // Check is this a Validation Exception
                case ValidationException _:
                    response.Message = context.Exception.GetType().Name;
                    response.MessageDetails = context.Exception.Message;
                    break;
                default:
                    response.Message = "Something went wrong";
                    response.MessageDetails = "Something went wrong. Please try again.";
                    break;
            }

            return new BadRequestObjectResult(response);
        }

        /// <summary>
        /// On Exception this method will execute in run time
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            BaseResponse baseResponse;

            CreateLogBaseContext(context);

            try
            {
                // Try to cast exception to a GlobalException
                baseResponse = ((GlobalException)context.Exception).Response;
            }
            catch
            {
                WriteExceptionLog(context, true);
                baseResponse = new BaseResponse();
            }

            // Get the most inner exception that occured
            while (context.Exception.InnerException != null)
            {
                context.Exception = context.Exception.InnerException;
            }

            // Create a BadRequest Response
            BadRequestObjectResult response = BuildResponse(baseResponse, context);

            context.Result = response;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;

            // Add Properties about the response
            LogContext.PushProperty("Response|ActionResult", JsonConvert.SerializeObject(((ObjectResult) context.Result).Value));
            LogContext.PushProperty("StatusCode", context.HttpContext.Response.StatusCode);
            
            WriteExceptionLog(context);
        }
    }
}
