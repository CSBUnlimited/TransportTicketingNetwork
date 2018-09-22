
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using Utilities.Logging.Common.Attributes;
using Utilities.Logging.Extensions;

namespace Utilities.Logging.Common.Filters
{
    public class ActivityLogActionFilter : IActionFilter
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<ActivityLogActionFilter>();

        public void OnActionExecuting(ActionExecutingContext context)
        {
            LogContext.PushProperty("Exchange", "Request");
            LogContext.PushProperty("Controller", context.RouteData.Values["controller"]);
            LogContext.PushProperty("Action", context.RouteData.Values["action"]);
            LogContext.PushProperty("ActivityType", context.HttpContext.Request.Method);
            LogContext.PushProperty("RequestPath", context.HttpContext.Request.Path);
            foreach (var arg in context.ActionArguments)
            {
                LogContext.PushProperty("Request|" + arg.Key, JsonConvert.SerializeObject(arg.Value));
            }

            Log.Activity($"{context.HttpContext.Request.Method} Request to {context.HttpContext.Request.Path}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            ControllerActionDescriptor actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            if (actionDescriptor != null)
            {
                EnableActivityLog controllerAttribute = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerTypeInfo.GetCustomAttribute<EnableActivityLog>();
                EnableActivityLog actionAttribute = actionDescriptor.MethodInfo.GetCustomAttribute<EnableActivityLog>();

                LogContext.PushProperty("Exchange", "Response");
                LogContext.PushProperty("Controller", context.RouteData.Values["controller"]);
                LogContext.PushProperty("Action", context.RouteData.Values["action"]);
                LogContext.PushProperty("ActivityType", context.HttpContext.Request.Method);
                LogContext.PushProperty("RequestPath", context.HttpContext.Request.Path);

                if (context.Result == null || context.Result.GetType().GetInterface(nameof(EmptyResult)) != null)
                {
                    return;
                }
                if (context.Result != null && (controllerAttribute != null || actionAttribute != null))
                {
                    if (context.Result.GetType().GetInterface(nameof(IActionResult)) != null)
                    {
                        if (context.Result.GetType() == typeof(FileStreamResult))
                        {
                            LogContext.PushProperty("Response|File", ((FileStreamResult)context.Result).FileDownloadName);
                        }
                        else
                        {
                            LogContext.PushProperty("Response|ActionResult", ((ActionResult)context.Result).ToString());
                        }
                    }
                    else if (((ObjectResult)context.Result).Value.GetType().GetInterface(nameof(IEnumerable)) != null)
                    {
                        int index = 1;
                        foreach (var response in (IEnumerable)((ObjectResult)context.Result).Value)
                        {
                            LogContext.PushProperty("Response|" + index.ToString(), JsonConvert.SerializeObject(response));
                            index++;
                        }
                    }
                    else
                    {
                        LogContext.PushProperty("Response", JsonConvert.SerializeObject(((ObjectResult)context.Result).Value));
                    }

                    Log.Activity($"Response from {context.HttpContext.Request.Path}");
                }
            }
        }
    }
}
