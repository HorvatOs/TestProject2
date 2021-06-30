using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common.Paging;
using Vehicle.Common.Paiging;
using Vehicle.DAL.Entity;
using Vehicle.Model.Common.Interface;
using Vehicle.Model.Models;

namespace Vehicle.Repository.Common.Interface
{
    public interface IMakeRepository
    {
        Task<IEnumerable<IVehicleMake>> GetAllMakesAsync(PagingParameters pagingParameters);
        Task<IVehicleMake> GetMakeByIdAsync(int id);
        Task<int> CreateMakeAsync(VehicleMake vehicleMake);
        Task<int> UpdateMakeAsync(VehicleMake vehicleMake);
        Task<int> DeleteMakeAsync(int id);
    }
}
