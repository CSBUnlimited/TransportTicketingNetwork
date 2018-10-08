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
    public class BusStopService : BaseService, IBusStopService
    {
        private IMainUnitOfWork _mainUnitOfWork;
        private IMapper _mapper;

        public BusStopService(IMainUnitOfWork mainUnitOfWork, IMapper mapper)
        {
            _mainUnitOfWork = mainUnitOfWork;
            _mapper = mapper;


        }
        public async Task<BusStopViewModel> AddBusStop(BusStopViewModel busstops)
        {
            BusStop busstop = _mapper.Map<BusStop>(busstops);

            await _mainUnitOfWork.BusStopRepository.AddBusStops(busstop);

            return _mapper.Map<BusStopViewModel>(busstop);
        }

        public async Task<IEnumerable<BusStopViewModel>> GetBusStopListAsync()
        {
            IEnumerable<BusStop> busstops = await _mainUnitOfWork.BusStopRepository.GetBusStopList();

            return _mapper.Map<IEnumerable<BusStopViewModel>>(busstops);
        }


    }
}
