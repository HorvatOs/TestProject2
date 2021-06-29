using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Data;
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
            var vehicleModel = await _db.VehicleModels.FirstOrDefaultAsync(x => x.Id == id);

            _db.VehicleModels.Remove(vehicleModel);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;

        }

        public async Task<IEnumerable<VehicleModel>> GetAllModelsAsync(int makeId)
        {
            return await _db.VehicleModels.ToListAsync();
        }


        public async Task<VehicleModel> GetModelByIdAsync(int id)
        {
            var vehicleModel = await _db.VehicleModels.FirstOrDefaultAsync(o => o.Id == id);
            if (vehicleModel == null)
            {
                throw new Exception();
            }
            return vehicleModel;
        }
        public async Task<VehicleMake> GetVehicleMakeAsync(int id)
        {
            var vehicleMake = await _db.VehicleMakes
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

