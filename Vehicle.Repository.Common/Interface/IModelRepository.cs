using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Entity;
using Vehicle.Model.Common.Interface;
using Vehicle.Model.Models;

namespace Vehicle.Repository.Common.Interface
{
    public interface IModelRepository
    {
        Task<IEnumerable<VehicleModelEntity>> GetAllModelsAsync(int makeId);
        Task<VehicleModelEntity> GetModelByIdAsync(int id);
        Task<int> CreateModelAsync(VehicleModel vehicleModel);
        Task<int> UpdateModelAsync(VehicleModel vehicleModel);
        Task<int> DeleteModelAsync(int id);
        Task<VehicleMakeEntity> GetVehicleMakeAsync(int id);
    }
}
