using Common.Core.Repositories;
using Modules.Main.Models;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Core.Repositories
{
    public interface IJourneyRepository : IRepository
    {
       // Task<IEnumerable<Journey>> GetLocations(Journey journey);

        Task AddJourney(Journey journey);
    }
}
