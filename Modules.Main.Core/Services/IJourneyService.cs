using Common.Core.Services;
using Modules.Main.Models;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Core.Services
{
    public interface IJourneyService: IService
    {
            //Method For Adding a Route
            Task<JourneyViewModel> AddJourney(JourneyViewModel journey);

            //Task<IEnumerable<JourneyViewModel>> GetJourneyListAsync();
    }
}
