using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Core.Services
{
    public interface ISubRouteService
    {
        //Method For Adding a SubRoute
        SubRoute AddSubRoute(SubRoute subroutes);
    }
}
