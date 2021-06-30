using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.DAL.Entity;
using Vehicle.Model.Common.Interface;
using Vehicle.Model.Models;
using Vehicle.WebAPI.Dtos;

namespace Vehicle.WebAPI.Profiles
{
    public class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            CreateMap<VehicleModel, ModelCreateDto>();
            CreateMap<ModelCreateDto, VehicleModel>();

            CreateMap<VehicleModel, ModelReadDto>();
            CreateMap<ModelReadDto, VehicleModel>();

            CreateMap<VehicleModel, ModelUpdateDto>();
            CreateMap<ModelUpdateDto, VehicleModel>();

            CreateMap<VehicleModelEntity, VehicleModel>();
            CreateMap<VehicleModel, VehicleModelEntity>();

            CreateMap<VehicleModelEntity, IVehicleModel>();
            CreateMap<IVehicleModel, VehicleModelEntity>();
        }
    }
}
