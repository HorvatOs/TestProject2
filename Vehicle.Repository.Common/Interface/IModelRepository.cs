using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Models;

namespace Vehicle.Repository.Common.Interface
{
    public interface IModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetAllModels(int makeId);
        Task<VehicleModel> GetModelById(int? id);
        Task<int> CreateModel(VehicleModel vehicleModel);
        Task<int> UpdateModel(VehicleModel vehicleModel);
        Task<int> DeleteModel(int? id);
        Task<VehicleMake> GetVehicleMake(int? id);
    }
}
