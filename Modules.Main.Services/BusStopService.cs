using AutoMapper;
using Common.Base.Services;
using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Services;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Services
{
    public class BusStopService : BaseService, IBusStopService
    {
        private IMainUnitOfWork _mainUnitOfWork;
        private IMapper _mapper;

        public BusStopService(IMainUnitOfWork mainUnitOfWork, IMapper mapper)
        {
            _mainUnitOfWork = mainUnitOfWork;


        }

        private IBusStopService _busStopServices;

       
        //Overide The AddBusStop Method
        public BusStop AddBusStop(BusStop busstops) {
            throw new System.NotImplementedException();
        }
    }
}
