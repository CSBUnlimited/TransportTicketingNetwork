using AutoMapper;
using Modules.Main.Models;
using Modules.Main.ViewModels;

namespace Modules.Main.Common.Configurations
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMapsModelsToViewModels();
            CreateMapViewModelsToModels();
        }

        private void CreateMapsModelsToViewModels()
        {
            CreateMap<Route, RouteViewModel>();
            CreateMap<Bus, BusViewModel>();




        }

        private void CreateMapViewModelsToModels()
        {
            CreateMap<RouteViewModel, Route>();
        }
    }
}
