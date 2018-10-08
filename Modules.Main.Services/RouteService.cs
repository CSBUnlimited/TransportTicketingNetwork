using AutoMapper;
using Common.Base.Services;
using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Services;
using Modules.Main.Models;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Services
{
    public class RouteService : BaseService, IRouteService
    {
        private IMainUnitOfWork _mainUnitOfWork;
        private IMapper _mapper;

        public RouteService(IMainUnitOfWork mainUnitOfWork, IMapper mapper) {
            _mainUnitOfWork = mainUnitOfWork;

            _mapper = mapper;
        }
        //Overide The AddRoute Method
        public async Task<RouteViewModel> AddRoute(RouteViewModel routes)
        {
            Route route = _mapper.Map<Route>(routes);

            await _mainUnitOfWork.RouteRepository.AddRoutes(route);

            return _mapper.Map<RouteViewModel>(route);
        }

        public async Task<IEnumerable<RouteViewModel>> GetRouteListAsync()
        {
            IEnumerable<Route> routes = await _mainUnitOfWork.RouteRepository.GetRouteList();

            return _mapper.Map<IEnumerable<RouteViewModel>>(routes);
        }


    }
}
