using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common.Paging;
using Vehicle.Common.Paiging;
using Vehicle.DAL.Entity;
using Vehicle.Model.Common.Interface;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;
using Vehicle.Repository.Models;
using Vehicle.Service.Common.Interface;

namespace Vehicle.Service.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        public VehicleMakeService(IMakeRepository vehicleMakeRepository, IMapper mapper)
        {
            VehicleMakeRepository = vehicleMakeRepository;
            _mapper = mapper;
        }
        public IMakeRepository VehicleMakeRepository { get; set; }
        private readonly IMapper _mapper;



        public async Task<IVehicleMake> GetMakeByIdServiceAsync (int id)
        {
            return _mapper.Map<IVehicleMake>(await VehicleMakeRepository.GetMakeByIdAsync(id));
        }


        public async Task<int> CreateMakeServiceAsync (VehicleMake vehicleMake)
        {
            return await VehicleMakeRepository.CreateMakeAsync(vehicleMake);
        }


        public async Task<int> DeleteMakeServiceAsync (int id)
        {
            return await VehicleMakeRepository.DeleteMakeAsync(id);
        }


        public async Task<IEnumerable<IVehicleMake>> GetAllMakesServiceAsync(PagingParameters pagingParameters)
        {
            return _mapper.Map<IEnumerable<IVehicleMake>>(await VehicleMakeRepository.GetAllMakesAsync(pagingParameters));
        }


        public async Task<int> UpdateMakeServiceAsync (VehicleMake vehicleMake)
        {
            return await VehicleMakeRepository.UpdateMakeAsync(vehicleMake);
        }
    }
}
