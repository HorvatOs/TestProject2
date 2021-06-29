using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;
using Vehicle.Repository.Models;
using Vehicle.Service.Common.Interface;

namespace Vehicle.Service.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        public VehicleModelService(IModelRepository vehicleModelRepository)
        {
            VehicleModelRepository = vehicleModelRepository;
        }

        public IModelRepository VehicleModelRepository { get; set; }



        public async Task<VehicleModel> GetModelByIdServiceAsync (int id)
        {
            return await VehicleModelRepository.GetModelByIdAsync(id);
        }

        public async Task<IEnumerable<VehicleModel>> GetAllModelsServiceAsync (int makeId)
        {
            return await VehicleModelRepository.GetAllModelsAsync(makeId);
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

        public async Task<VehicleMake> GetVehicleMakeServiceAsync (int id)
        {
            return await VehicleModelRepository.GetVehicleMakeAsync(id);
        }
    }
}
