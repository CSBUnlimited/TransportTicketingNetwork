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
    public class JourneyService : BaseService, IJourneyService
    {
        private IMainUnitOfWork _mainUnitOfWork;
        private IMapper _mapper;

        public JourneyService(IMainUnitOfWork mainUnitOfWork, IMapper mapper)
        {
            _mainUnitOfWork = mainUnitOfWork;

            _mapper = mapper;


        }
        //Overide The AddJourney Method
        public async Task<JourneyViewModel> AddJourney(JourneyViewModel journeys)
        {
            Journey journey = _mapper.Map<Journey>(journeys);

            await _mainUnitOfWork.JourneyRepository.AddJourneys(journey);

            return _mapper.Map<JourneyViewModel>(journey);
        }

        public async Task<IEnumerable<JourneyViewModel>> GetJourneyListAsync()
        {
            IEnumerable<Journey> journeys = await _mainUnitOfWork.JourneyRepository.GetJourneyList();

            return _mapper.Map<IEnumerable<JourneyViewModel>>(journeys);
        }



    }
}
