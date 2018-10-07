using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace General.Tools.SeedHelpers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            StringBuilder output = new StringBuilder();

            output.Append("/************************************************************************************************************************************\r\n");
            output.Append(" Description: This script generates all relevant ApiProject => Controller => ApiFunction mappings from api project source code. \r\n");
            output.Append(" Re-Generation: Run, TransportTicketingNetwork => 1000 General => 1002 Tools => General.Tools.SeedHelpers.WebAPI => Controllers => ValuesController => Get() \r\n");
            output.Append(" Author: Chathuranga Basnayake \r\n");
            output.Append(" Date: 2018-10-05 \r\n");
            output.AppendFormat(" Generated Date: {0:yyyy-MM-dd hh:mm:ss tt} \r\n", DateTime.Now);
            output.Append("************************************************************************************************************************************/\r\n");
            output.Append("\r\n");

            //Collecting assemblies
            Dictionary<ModuleEnum, Type> assemblyTypeCollection = new Dictionary<ModuleEnum, Type>
            {
                { ModuleEnum.Main, typeof(Modules.Main.WebAPI.Controllers.AuthorizationController)}
            };

            foreach (ModuleEnum module in assemblyTypeCollection.Keys)
            {
                Type selectedType = assemblyTypeCollection[module];

                // Get project
                Assembly assembly = Assembly.GetAssembly(selectedType);
                string assemblyName = assembly.GetName().Name;

                //Collect controller list
                var controllersList = assembly.GetTypes()
                        .Where(type => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(type))
                        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                        // .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())                        
                        .Select(x => new { Controller = x.DeclaringType.Name })
                        .OrderBy(x => x.Controller)
                        .Distinct()
                        .ToList();

                foreach (var controller in controllersList)
                {
                    //Write controller list
                    output.AppendFormat("/***** Insert Controller: {0} => {1} ********************************/\r\n", assemblyName, controller.Controller);

                    StringBuilder controlInsertQuery = new StringBuilder();
                    controlInsertQuery.Append("INSERT INTO [usm].[ApiController](ApiProjectId,ControllerName,CreatedUserId,LastModifiedUserId)\r\n");
                    controlInsertQuery.Append("SELECT");
                    controlInsertQuery.Append(" Id,");
                    controlInsertQuery.AppendFormat(" '{0}',", controller.Controller);
                    controlInsertQuery.Append(" 1,");
                    controlInsertQuery.Append(" 1");
                    controlInsertQuery.Append(" FROM [usm].[ApiProject]");
                    controlInsertQuery.AppendFormat(" WHERE Name='{0}'\r\n", assemblyName);

                    output.Append(controlInsertQuery.ToString());
                    output.Append("\r\n");
                }

                //Collect Controller/Actions List
                var actionsList = assembly.GetTypes()
                        .Where(type => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(type))
                        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                        .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name })
                        .OrderBy(x => x.Controller).ThenBy(x => x.Action)
                        .Distinct()
                        .ToList();

                foreach (var action in actionsList)
                {
                    //Write action list
                    output.AppendFormat("/***** Insert Function: {0} => {1} => {2} ********************************/\r\n", assemblyName, action.Controller, action.Action);

                    StringBuilder actionInsertQuery = new StringBuilder();
                    actionInsertQuery.Append("INSERT INTO [usm].[ApiFunction](ApiControllerId,ActionName,Description,CreatedUserId,LastModifiedUserId)\r\n");
                    actionInsertQuery.Append("SELECT");
                    actionInsertQuery.Append(" AC.Id AS ControllerId,");
                    actionInsertQuery.AppendFormat(" '{0}',", action.Action);
                    actionInsertQuery.AppendFormat(" '{0}',", action.Action);
                    actionInsertQuery.Append(" 1,");
                    actionInsertQuery.Append(" 1");
                    actionInsertQuery.Append(" FROM [usm].[ApiController] AC");
                    actionInsertQuery.AppendFormat(" INNER JOIN [usm].[ApiProject] AP ON AC.ApiProjectId=AP.Id AND AC.ControllerName='{0}' AND AP.Name='{1}'\r\n", action.Controller, assemblyName);

                    output.Append(actionInsertQuery.ToString());

                    output.Append("\r\n");
                }
            }

            return output.ToString();
        }
    }
}
