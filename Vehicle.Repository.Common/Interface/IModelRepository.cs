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
        Task<IEnumerable<IVehicleModel>> GetAllModelsAsync(int makeId);
        Task<IVehicleModel> GetModelByIdAsync(int id);
        Task<int> CreateModelAsync(IVehicleModel vehicleModel);
        Task<int> UpdateModelAsync(IVehicleModel vehicleModel);
        Task<int> DeleteModelAsync(int id);
        Task<IVehicleMake> GetVehicleMakeAsync(int id);
    }
}
