using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common.Paiging;
using Vehicle.Model.Models;

namespace Vehicle.Repository.Common.Interface
{
    public interface IMakeRepository
    {
        Task<IEnumerable<VehicleMake>> GetAllMakesAsync(PagingParameters pagingParameters);
        Task<VehicleMake> GetMakeByIdAsync(int? id);
        Task<int> CreateMakeAsync(VehicleMake vehicleMake);
        Task<int> UpdateMakeAsync(VehicleMake vehicleMake);
        Task<int> DeleteMakeAsync(int? id);
    }
}
