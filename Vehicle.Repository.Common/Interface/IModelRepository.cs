using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Models;

namespace Vehicle.Repository.Common.Interface
{
    public interface IModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetAllModelsAsync(int makeId);
        Task<VehicleModel> GetModelByIdAsync(int id);
        Task<int> CreateModelAsync(VehicleModel vehicleModel);
        Task<int> UpdateModelAsync(VehicleModel vehicleModel);
        Task<int> DeleteModelAsync(int id);
        Task<VehicleMake> GetVehicleMakeAsync(int id);
    }
}
