using Common.Core.Services;
using Modules.Main.Models;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Core.Services
{
    public interface IRouteService : IService
    {
        //Method For Adding a Route
        Task<RouteViewModel> AddRoute(RouteViewModel routes);

        Task<IEnumerable<RouteViewModel>> GetRouteListAsync();


    }
}
