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
    public class SqlMakeRepository : IMakeRepository
    {
        private readonly VehicleContext _db;

        public SqlMakeRepository(VehicleContext db)
        {
            _db = db;
        }

        public async Task<int> CreateMake(VehicleMake vehicleMake)
        {
            _db.Add(vehicleMake);
            var numberOfCreated = await _db.SaveChangesAsync();
            return numberOfCreated;
        }

        public async Task<int> DeleteMake(int? id)
        {
            var vehicleMake = await _db.VehicleMakes.FirstOrDefaultAsync(x => x.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception("Not found");
            }
            _db.VehicleMakes.Remove(vehicleMake);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;
        }

        public async Task<IEnumerable<VehicleMake>> GetAllMakes()
        {
            return await _db.VehicleMakes.ToListAsync();
        }

        public Task<VehicleMake> GetMakeById(int? id)
        {
            var vehicleMake = _db.VehicleMakes.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMake == null)
            {
                throw new ArgumentNullException();
            }
            return vehicleMake;
        }

        public Task<int> UpdateMake(VehicleMake vehicleMake)
        {
            _db.Update(vehicleMake);
            var numberOfChanges = _db.SaveChangesAsync();

            return numberOfChanges;
        }
    }
}