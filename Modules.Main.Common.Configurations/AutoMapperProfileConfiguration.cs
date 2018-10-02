﻿using AutoMapper;
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
            CreateMap<BusSchedule, BusScheduleViewModel>();
            CreateMap<Journey, JourneyViewModel>();

        }

        private void CreateMapViewModelsToModels()
        {
            CreateMap<RouteViewModel, Route>();
            CreateMap<BusViewModel, Bus>();
            CreateMap<BusScheduleViewModel, BusSchedule>();
            CreateMap<JourneyViewModel, Journey>();

        }
    }
}
