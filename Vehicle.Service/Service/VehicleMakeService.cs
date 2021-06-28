using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Common.Interface;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;
using Vehicle.Repository.Models;

namespace Vehicle.Service.Service
{
    public class VehicleMakeService
    {
        public VehicleMakeService(IMakeRepository vehicleMakeRepository)
        {
            VehicleMakeRepository = vehicleMakeRepository;
        }

        public IMakeRepository VehicleMakeRepository { get; set; }



        public async Task<IVehicleMake> GetMakeByIdServiceAsync (int id)
        {
            return await VehicleMakeRepository.GetMakeByIdAsync(id);
        }

        public async Task<int> CreateMakeServiceAsync (VehicleMake vehicleMake)
        {
            return await VehicleMakeRepository.CreateMakeAsync(vehicleMake);
        }

        public async Task<int> DeleteMakeServiceAsync (int id)
        {
            return await VehicleMakeRepository.DeleteMakeAsync(id);
        }

        public async Task<IEnumerable<VehicleMake>> GetAllMakesServiceAsync()
        {
            return await VehicleMakeRepository.GetAllMakesAsync();
        }

        public async Task<int> UpdateMakeServiceAsync (VehicleMake vehicleMake)
        {
            return await VehicleMakeRepository.UpdateMakeAsync(vehicleMake);
        }
    }
}
