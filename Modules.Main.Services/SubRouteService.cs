using System;
using System.Collections.Generic;
using System.Text;
using Modules.Main.Core.Services;
using Modules.Main.Models;

namespace Modules.Main.Services
{
    public class SubRouteService : ISubRouteService
    {
        private ISubRouteService _subRouteServices;
        public SubRouteService(ISubRouteService subRouteServices) {

            _subRouteServices = subRouteServices;
        }
        //Overide The AddSubRoute Method
        public SubRoute AddSubRoute(SubRoute subroutes) {
            throw new System.NotImplementedException();
        }
    }
}
