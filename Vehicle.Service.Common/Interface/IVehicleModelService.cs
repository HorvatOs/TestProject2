using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Entity;
using Vehicle.Model.Common.Interface;
using Vehicle.Model.Models;

namespace Vehicle.Service.Common.Interface
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<IVehicleModel>> GetAllModelsServiceAsync(int makeId);
        Task<IVehicleModel> GetModelByIdServiceAsync(int id);
        Task<int> CreateModelServiceAsync(IVehicleModel vehicleModel);
        Task<int> UpdateModelServiceAsync(IVehicleModel vehicleModel);
        Task<int> DeleteModelServiceAsync(int id);
        Task<IVehicleMake> GetVehicleMakeServiceAsync(int id);
    }
}
