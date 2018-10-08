using AutoMapper;
using Common.Base.Services;
using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Services;
using Modules.Main.Models;
using Modules.Main.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modules.Main.Services
{
    public class BusService : BaseService, IBusService
    {
        private readonly IMainUnitOfWork _mainUnitOfWork;
        private readonly IMapper _mapper;

        public BusService(IMainUnitOfWork mainUnitOfWork, IMapper mapper)
        {
            _mainUnitOfWork = mainUnitOfWork;
            _mapper = mapper;
        }

        public async Task<BusViewModel> GetBusAsync(string busNumber)
        {
            Bus bus = await _mainUnitOfWork.BusRepository.GetBus(busNumber);

            return _mapper.Map<BusViewModel>(bus);
        }

        public async Task<IEnumerable<BusViewModel>> GetBusListAsync()
        {
            IEnumerable<Bus> buses = await _mainUnitOfWork.BusRepository.GetBusList();

            return _mapper.Map<IEnumerable<BusViewModel>>(buses);
        }

        public async Task<BusViewModel> AddBusAsync(BusViewModel buses)
        {
            Bus bus = _mapper.Map<Bus>(buses);

            await _mainUnitOfWork.BusRepository.AddBus(bus);

            return _mapper.Map<BusViewModel>(bus);
        }

        public async Task<BusViewModel> DeleteBus(string busNumber)
        {
            Bus bus = await _mainUnitOfWork.BusRepository.GetBus(busNumber);

            _mainUnitOfWork.BusRepository.DeleteBus(bus);

            return _mapper.Map<BusViewModel>(bus);
        }

        public async Task<BusViewModel> UpdateBusAsync(string busNumber, BusViewModel updatedBus)
        {
            //Changes
            Bus mUpdatedBus = _mapper.Map<Bus>(updatedBus);

            Bus bus = await _mainUnitOfWork.BusRepository.GetBus(mUpdatedBus.BusNumber);

            bus.BusName = mUpdatedBus.BusName;
            bus.BusNumber = mUpdatedBus.BusNumber;
            bus.BusType = mUpdatedBus.BusType;
            bus.NoSeats = mUpdatedBus.NoSeats;
            bus.Description = mUpdatedBus.Description;
            bus.RouteId = mUpdatedBus.RouteId;
            bus.Route = mUpdatedBus.Route;
            
            _mainUnitOfWork.BusRepository.UpdateBus(bus);

            return _mapper.Map<BusViewModel>(bus);

        }

       
    }
}
