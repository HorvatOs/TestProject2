using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Models;

namespace Vehicle.Repository.Common.Interface
{
    public interface IMakeRepository
    {
        Task<IEnumerable<VehicleMake>> GetAllMakes();
        Task<VehicleMake> GetMakeById(int? id);
        Task<int> CreateMake(VehicleMake vehicleMake);
        Task<int> UpdateMake(VehicleMake vehicleMake);
        Task<int> DeleteMake(int? id);
    }
}
