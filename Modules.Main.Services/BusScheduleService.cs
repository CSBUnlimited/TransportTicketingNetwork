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


    }
}
