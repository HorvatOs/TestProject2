using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Entity;
using Vehicle.Model.Common.Interface;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;
using Vehicle.Repository.Models;
using Vehicle.Service.Common.Interface;

namespace Vehicle.Service.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        public VehicleModelService(IModelRepository vehicleModelRepository, IMapper mapper)
        {
            VehicleModelRepository = vehicleModelRepository;
            _mapper = mapper;
        }
        public IModelRepository VehicleModelRepository { get; set; }
        private readonly IMapper _mapper;



        public async Task<IVehicleModel> GetModelByIdServiceAsync (int id)
        {
            return _mapper.Map<IVehicleModel>(await VehicleModelRepository.GetModelByIdAsync(id));
        }


        public async Task<IEnumerable<IVehicleModel>> GetAllModelsServiceAsync (int makeId)
        {
            return _mapper.Map<IEnumerable<IVehicleModel>>(await VehicleModelRepository.GetAllModelsAsync(makeId));
        }


        public async Task<int> CreateModelServiceAsync (VehicleModel vehicleModel)
        {
            return await VehicleModelRepository.CreateModelAsync(vehicleModel);
        }


        public async Task<int> DeleteModelServiceAsync (int id)
        {
            return await VehicleModelRepository.DeleteModelAsync(id);
        }


        public async Task<int> UpdateModelServiceAsync (VehicleModel vehicleModel)
        {
            return await VehicleModelRepository.UpdateModelAsync(vehicleModel);
        }


        public async Task<IVehicleMake> GetVehicleMakeServiceAsync (int id)
        {
            return _mapper.Map<IVehicleMake>(await VehicleModelRepository.GetVehicleMakeAsync(id));
        }
    }
}
