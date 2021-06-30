using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Entity;
using Vehicle.Model.Models;

namespace Vehicle.Service.Common.Interface
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModelEntity>> GetAllModelsServiceAsync(int makeId);
        Task<VehicleModelEntity> GetModelByIdServiceAsync(int id);
        Task<int> CreateModelServiceAsync(VehicleModel vehicleModel);
        Task<int> UpdateModelServiceAsync(VehicleModel vehicleModel);
        Task<int> DeleteModelServiceAsync(int id);
        Task<VehicleMakeEntity> GetVehicleMakeServiceAsync(int id);
    }
}
