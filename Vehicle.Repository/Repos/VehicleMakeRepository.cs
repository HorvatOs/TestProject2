using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Common.Paging;
using Vehicle.Common.Paiging;
using Vehicle.DAL.Data;
using Vehicle.DAL.Entity;
using Vehicle.Model.Common.Interface;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;

namespace Vehicle.Repository.Models
{
    public class VehicleMakeRepository : IMakeRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper _mapper;
        public VehicleMakeRepository(VehicleContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }



        public async Task<int> CreateMakeAsync(IVehicleMake vehicleMake)
        {
            _db.Add(_mapper.Map<VehicleMakeEntity>(vehicleMake));
            var numberOfCreated = await _db.SaveChangesAsync();
            return numberOfCreated;
        }


        public async Task<int> DeleteMakeAsync(int id)
        {
            var vehicleMake = await _db.VehicleMakesEntity.FirstOrDefaultAsync(x => x.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception("Not found");
            }
            _db.VehicleMakesEntity.Remove(vehicleMake);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;
        }


        public async Task<IEnumerable<IVehicleMake>> GetAllMakesAsync(PagingParameters pagingParameters)
        {
            var pageSize = pagingParameters.PageSize;
            var pageNumber = pagingParameters.PageNumber;
            var makes = await _db.VehicleMakesEntity.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return _mapper.Map<IEnumerable<IVehicleMake>>(makes);
        }


        public async Task<IVehicleMake> GetMakeByIdAsync(int id)
        {
            var vehicleMake = await _db.VehicleMakesEntity.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception();
            }
            return _mapper.Map<IVehicleMake>(vehicleMake);
        }


        public async Task<int> UpdateMakeAsync(IVehicleMake vehicleMake)
        {
            _db.Update(_mapper.Map<VehicleMakeEntity>(vehicleMake));
            var numberOfChanges = await _db.SaveChangesAsync();
            return numberOfChanges;
        }
    }
}