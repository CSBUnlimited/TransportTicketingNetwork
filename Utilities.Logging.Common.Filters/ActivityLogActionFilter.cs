using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using Utilities.Authorization.Common.Models;
using Utilities.Logging.Common.Attributes;
using Utilities.Logging.Extensions;

namespace Utilities.Logging.Common.Filters
{
    /// <summary>
    /// This class responsible for do run time logs for every request and response
    /// </summary>
    public class ActivityLogActionFilter : IActionFilter
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<ActivityLogActionFilter>();
        private readonly RequestInformation _requestInformation;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestInformation">Request Information</param>
        public ActivityLogActionFilter(RequestInformation requestInformation)
        {
            _requestInformation = requestInformation;
        }

        /// <summary>
        /// Calls in run time - when a request comes to the controller
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.ActionDescriptor is ControllerActionDescriptor actionDescriptor))
                return;

            DisableActivityLog controllerAttribute = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerTypeInfo.GetCustomAttribute<DisableActivityLog>();
            DisableActivityLog actionAttribute = actionDescriptor.MethodInfo.GetCustomAttribute<DisableActivityLog>();
            
            // Check DisableActivityLog is in the controller/ method
            if (!(controllerAttribute == null && actionAttribute == null))
            {
                return;
            }

            LogContext.PushProperty("Exchange", "Request");
            LogContext.PushProperty("Controller", context.RouteData.Values["controller"]);
            LogContext.PushProperty("Action", context.RouteData.Values["action"]);
            LogContext.PushProperty("ActivityType", context.HttpContext.Request.Method);
            LogContext.PushProperty("RequestPath", context.HttpContext.Request.Path);

            LogContext.PushProperty("RequestedIPAddress", _requestInformation.RequestedIpAddress);

            if (_requestInformation.SessionHash != null)
            {
                LogContext.PushProperty("SessionHash", _requestInformation.SessionHash);
            }

            foreach (KeyValuePair<string, object> arg in context.ActionArguments)
            {
                LogContext.PushProperty($"Request|{arg.Key}", JsonConvert.SerializeObject(arg.Value));
            }

            Log.Activity();
        }

        /// <summary>
        /// Calls in run time - when a controller method executed successfully
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!(context.ActionDescriptor is ControllerActionDescriptor actionDescriptor)) return;

            DisableActivityLog controllerAttribute = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerTypeInfo.GetCustomAttribute<DisableActivityLog>();
            DisableActivityLog actionAttribute = actionDescriptor.MethodInfo.GetCustomAttribute<DisableActivityLog>();
            
            // Check whether context result is null or empty or DisableActivityLog is in the controller/ method
            if (context.Result == null || context.Result.GetType().GetInterface(nameof(EmptyResult)) != null
                                       || !(controllerAttribute == null && actionAttribute == null))
            {
                return;
            }

            LogContext.PushProperty("Exchange", "Response");
            LogContext.PushProperty("Controller", context.RouteData.Values["controller"]);
            LogContext.PushProperty("Action", context.RouteData.Values["action"]);
            LogContext.PushProperty("ActivityType", context.HttpContext.Request.Method);
            LogContext.PushProperty("RequestPath", context.HttpContext.Request.Path);

            LogContext.PushProperty("RequestedIPAddress", _requestInformation.RequestedIpAddress);

            if (_requestInformation.SessionHash != null)
            {
                LogContext.PushProperty("SessionHash", _requestInformation.SessionHash);
            }

            if (context.Result.GetType().GetInterface(nameof(IActionResult)) != null)
            {
                if (context.Result.GetType() == typeof(FileStreamResult))
                {
                    LogContext.PushProperty("Response|File", ((FileStreamResult)context.Result).FileDownloadName);
                }
                else
                {
                    LogContext.PushProperty("Response|ActionResult", JsonConvert.SerializeObject(((ObjectResult)context.Result).Value));
                }
            }
            else if (((ObjectResult)context.Result).Value.GetType().GetInterface(nameof(IEnumerable)) != null)
            {
                int index = 1;
                foreach (object response in (IEnumerable)((ObjectResult)context.Result).Value)
                {
                    LogContext.PushProperty($"Response|{index.ToString()}", JsonConvert.SerializeObject(response));
                    index++;
                }
            }
            else
            {
                LogContext.PushProperty("Response", JsonConvert.SerializeObject(((ObjectResult)context.Result).Value));
            }

            LogContext.PushProperty("StatusCode", context.HttpContext.Response.StatusCode);
            Log.Activity();

        }
    }
}
