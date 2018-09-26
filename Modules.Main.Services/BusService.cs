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
    public class BusService : BaseService, IBusService
    {
        private readonly IMainUnitOfWork _mainUnitOfWork;
        private readonly IMapper _mapper;

        public BusService(IMainUnitOfWork mainUnitOfWork, IMapper mapper)
        {
            _mainUnitOfWork = mainUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BusViewModel>> GetBusListAsync()
        {
            IEnumerable<Bus> buses = await _mainUnitOfWork.BusRepository.GetBusList();

            return _mapper.Map<IEnumerable<BusViewModel>>(buses);
        }
    }
}
