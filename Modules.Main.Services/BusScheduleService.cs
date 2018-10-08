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
    public class BusScheduleService : BaseService, IBusScheduleService
    {
        private readonly IMainUnitOfWork _mainUnitOfWork;
        private readonly IMapper _mapper;

        public BusScheduleService(IMainUnitOfWork mainUnitOfWork, IMapper mapper)
        {
            _mainUnitOfWork = mainUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BusScheduleViewModel>> GetBusScheduleListAsync()
        {
            IEnumerable<BusSchedule> busSchedules = await _mainUnitOfWork.BusScheduleRepository.GetBusScheduleList();

            return _mapper.Map<IEnumerable<BusScheduleViewModel>>(busSchedules);
        }

        public async Task<BusScheduleViewModel> AddBusScheduleAsync(BusScheduleViewModel busSchedules)
        {
            BusSchedule busSchedule = _mapper.Map<BusSchedule>(busSchedules);

            await _mainUnitOfWork.BusScheduleRepository.AddBusSchedule(busSchedule);

            return _mapper.Map<BusScheduleViewModel>(busSchedule);
        }

        public async Task<BusScheduleViewModel> DeleteBusScheduleAsync(int id)
        {
            BusSchedule busSchedule = await _mainUnitOfWork.BusScheduleRepository.GetBusSchedule(id);

            _mainUnitOfWork.BusScheduleRepository.DeleteBusSchedule(busSchedule);

            return _mapper.Map<BusScheduleViewModel>(busSchedule);
        }

        public async Task<BusScheduleViewModel> UpdateBusScheduleAsync(int id, BusScheduleViewModel updatedBusSchedule)
        {
            //Changes
            BusSchedule mUpdatedBusSchedule = _mapper.Map<BusSchedule>(updatedBusSchedule);

            BusSchedule busSchedule = await _mainUnitOfWork.BusScheduleRepository.GetBusSchedule(mUpdatedBusSchedule.Id);

            busSchedule.Id = mUpdatedBusSchedule.Id;
            busSchedule.StartingPoint = mUpdatedBusSchedule.StartingPoint;
            busSchedule.Destination = mUpdatedBusSchedule.Destination;
            busSchedule.StartTime = mUpdatedBusSchedule.StartTime;
            busSchedule.EndTime = mUpdatedBusSchedule.EndTime;
            busSchedule.TotalDuration = mUpdatedBusSchedule.TotalDuration;
            busSchedule.StartBusStop = mUpdatedBusSchedule.StartBusStop;
            busSchedule.EndBusStop = mUpdatedBusSchedule.EndBusStop;
            busSchedule.AllocatedBus = mUpdatedBusSchedule.AllocatedBus;
           

            _mainUnitOfWork.BusScheduleRepository.UpdateBusSchedule(busSchedule);

            return _mapper.Map<BusScheduleViewModel>(busSchedule);
        }
    }
}
