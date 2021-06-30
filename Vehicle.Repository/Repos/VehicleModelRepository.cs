using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Data;
using Vehicle.DAL.Entity;
using Vehicle.Model.Common.Interface;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;

namespace Vehicle.Repository.Models
{
    public class VehicleModelRepository : IModelRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper _mapper;
        public VehicleModelRepository(VehicleContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }



        public async Task<int> CreateModelAsync(IVehicleModel vehicleModel)
        {
            _db.Add(_mapper.Map<VehicleModelEntity>(vehicleModel));
            var numberOfCreated = await _db.SaveChangesAsync();
            return numberOfCreated;
        }


        public async Task<int> DeleteModelAsync(int id)
        {
            var vehicleModel = await _db.VehicleModelsEntity.FirstOrDefaultAsync(x => x.Id == id);

            _db.VehicleModelsEntity.Remove(vehicleModel);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;
        }


        public async Task<IEnumerable<IVehicleModel>> GetAllModelsAsync(int makeId)
        {
            return (IEnumerable<IVehicleModel>)await _db.VehicleModelsEntity.ToListAsync();
        }


        public async Task<IVehicleModel> GetModelByIdAsync(int id)
        {
            var vehicleModel = await _db.VehicleModelsEntity.FirstOrDefaultAsync(o => o.Id == id);
            if (vehicleModel == null)
            {
                throw new Exception();
            }
            return (_mapper.Map<IVehicleModel>(vehicleModel));
        }


        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            var vehicleMake = await _db.VehicleMakesEntity
               .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception("Vehicle Make not found");
            }
            return (_mapper.Map<IVehicleMake>(vehicleMake));
        }


        public async Task<int> UpdateModelAsync(IVehicleModel vehicleModel)
        {
            _db.Update(_mapper.Map<VehicleModelEntity>(vehicleModel));
            var numberOfChanges = await _db.SaveChangesAsync();

            return numberOfChanges;
        }
    }
}

