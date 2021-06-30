using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Data;
using Vehicle.DAL.Entity;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;

namespace Vehicle.Repository.Models
{
    public class VehicleModelRepository : IModelRepository
    {
        private readonly VehicleContext _db;

        public VehicleModelRepository(VehicleContext db)
        {
            _db = db;
        }

        public async Task<int> CreateModelAsync(VehicleModel vehicleModel)
        {
            _db.Add(vehicleModel);
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

        public async Task<IEnumerable<VehicleModelEntity>> GetAllModelsAsync(int makeId)
        {
            return await _db.VehicleModelsEntity.ToListAsync();
        }


        public async Task<VehicleModelEntity> GetModelByIdAsync(int id)
        {
            var vehicleModel = await _db.VehicleModelsEntity.FirstOrDefaultAsync(o => o.Id == id);
            if (vehicleModel == null)
            {
                throw new Exception();
            }
            return vehicleModel;
        }
        public async Task<VehicleMakeEntity> GetVehicleMakeAsync(int id)
        {
            var vehicleMake = await _db.VehicleMakesEntity
               .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception("Vehicle Make not found");
            }
            return vehicleMake;
        }

        public async Task<int> UpdateModelAsync(VehicleModel vehicleModel)
        {
            _db.Update(vehicleModel);
            var numberOfChanges = await _db.SaveChangesAsync();

            return numberOfChanges;
        }
    }
}

