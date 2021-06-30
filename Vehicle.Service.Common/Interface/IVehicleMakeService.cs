using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common.Paging;
using Vehicle.Common.Paiging;
using Vehicle.DAL.Entity;
using Vehicle.Model.Common.Interface;
using Vehicle.Model.Models;

namespace Vehicle.Service.Common.Interface
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<IVehicleMake>> GetAllMakesServiceAsync(PagingParameters pagingParameters);
        Task<IVehicleMake> GetMakeByIdServiceAsync(int id);
        Task<int> CreateMakeServiceAsync(VehicleMake vehicleMake);
        Task<int> UpdateMakeServiceAsync(VehicleMake vehicleMake);
        Task<int> DeleteMakeServiceAsync(int id);
    }
}
