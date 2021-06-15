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
    public class SqlModelRepository : IModelRepository
    {
        private readonly VehicleContext _db;

        public SqlModelRepository(VehicleContext db)
        {
            _db = db;
        }

        public async Task<int> CreateModel(VehicleModel vehicleModel)
        {
            _db.Add(vehicleModel);
            var numberOfCreated = await _db.SaveChangesAsync();
            return numberOfCreated;
        }

        public async Task<int> DeleteModel(int? id)
        {
            var vehicleModel = await _db.VehicleModels.FirstOrDefaultAsync(x => x.Id == id);

            _db.VehicleModels.Remove(vehicleModel);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;

        }

        public async Task<IEnumerable<VehicleModel>> GetAllModels(int makeId)
        {
            return await _db.VehicleModels.ToListAsync();
        }


        public async Task<VehicleModel> GetModelById(int? id)
        {
            var vehicleModel = await _db.VehicleModels.FirstOrDefaultAsync(o => o.Id == id);
            if (vehicleModel == null)
            {
                throw new ArgumentNullException();
            }
            return vehicleModel;
        }
        public async Task<VehicleMake> GetVehicleMake(int? id)
        {
            var vehicleMake = await _db.VehicleMakes
               .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception("Vehicle Make not found");
            }
            return vehicleMake;
        }

        public Task<int> UpdateModel(VehicleModel vehicleModel)
        {
            _db.Update(vehicleModel);
            var numberOfChanges = _db.SaveChangesAsync();

            return numberOfChanges;
        }
    }
}

