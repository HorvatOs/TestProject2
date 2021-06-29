using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Models;

namespace Vehicle.Service.Common.Interface
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> GetAllModelsServiceAsync(int makeId);
        Task<VehicleModel> GetModelByIdServiceAsync(int id);
        Task<int> CreateModelServiceAsync(VehicleModel vehicleModel);
        Task<int> UpdateModelServiceAsync(VehicleModel vehicleModel);
        Task<int> DeleteModelServiceAsync(int id);
        Task<VehicleMake> GetVehicleMakeServiceAsync(int id);
    }
}
