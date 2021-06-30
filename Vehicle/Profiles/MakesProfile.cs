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
    public class MakesProfile : Profile
    {
        public MakesProfile()
        {
            CreateMap<VehicleMake, MakeCreateDto>();
            CreateMap<MakeCreateDto, VehicleMake>();

            CreateMap<VehicleMake, MakeUpdateDto>();
            CreateMap<MakeUpdateDto, VehicleMake>();

            CreateMap<VehicleMake, MakeReadDto>();
            CreateMap<MakeReadDto, VehicleMake>();

            CreateMap<VehicleMakeEntity, VehicleMake>();
            CreateMap<VehicleMake, VehicleMakeEntity>();

            CreateMap<VehicleMakeEntity, IVehicleMake>();
            CreateMap<IVehicleMake, VehicleMakeEntity>();

            CreateMap<IVehicleMake, MakeReadDto>();


        }
    }
}

