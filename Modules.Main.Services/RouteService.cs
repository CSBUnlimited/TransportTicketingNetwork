using Modules.Main.Core.Services;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Services
{
    public class RouteService : IRouteService
    {
        private IRouteService _routeServices;

        public RouteService(IRouteService routeServices) {

            _routeServices = routeServices;
        }
        //Overide The AddRoute Method
        public Route AddRoute(Route routes) {
            throw new System.NotImplementedException();
        }
    }
}
