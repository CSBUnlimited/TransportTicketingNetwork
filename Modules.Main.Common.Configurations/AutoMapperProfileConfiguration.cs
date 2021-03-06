﻿using System;
using AutoMapper;
using Common.Models;
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
            CreateMap<UserExt, UserViewModel>()
                .ForMember(uvm => uvm.Gender, opt => opt.MapFrom(u => Enum.GetName(typeof(GenderEnum), u.GenderEnum)));
            CreateMap<UserExt, UserExtViewModel>()
                .ForMember(uvm => uvm.Gender, opt => opt.MapFrom(u => Enum.GetName(typeof(GenderEnum), u.GenderEnum)));
            CreateMap<BusStop, BusStopViewModel>();

        }

        private void CreateMapViewModelsToModels()
        {
            CreateMap<RouteViewModel, Route>();
            CreateMap<BusViewModel, Bus>();
            CreateMap<BusScheduleViewModel, BusSchedule>();
            CreateMap<JourneyViewModel, Journey>();
            CreateMap<UserViewModel, UserExt>()
                .ForMember(u => u.GenderEnum, opt => opt.MapFrom(uvm => (GenderEnum)Enum.Parse(typeof(GenderEnum), uvm.Gender)));
            CreateMap<UserExtViewModel, UserExt>()
                .ForMember(u => u.GenderEnum, opt => opt.MapFrom(uvm => (GenderEnum)Enum.Parse(typeof(GenderEnum), uvm.Gender)));
            CreateMap<BusStopViewModel, BusStop>();

        }
    }
}
