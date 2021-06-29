using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common.Paging;
using Vehicle.Common.Paiging;
using Vehicle.Model.Models;

namespace Vehicle.Service.Common.Interface
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> GetAllMakesServiceAsync(PagingParameters pagingParameters);
        Task<VehicleMake> GetMakeByIdServiceAsync(int id);
        Task<int> CreateMakeServiceAsync(VehicleMake vehicleMake);
        Task<int> UpdateMakeServiceAsync(VehicleMake vehicleMake);
        Task<int> DeleteMakeServiceAsync(int id);
    }
}
