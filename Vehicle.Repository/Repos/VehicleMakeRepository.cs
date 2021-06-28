﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Common.Paiging;
using Vehicle.DAL.Data;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;

namespace Vehicle.Repository.Models
{
    public class VehicleMakeRepository : IMakeRepository
    {
        private readonly VehicleContext _db;

        public VehicleMakeRepository(VehicleContext db)
        {
            _db = db;
        }

        public async Task<int> CreateMakeAsync(VehicleMake vehicleMake)
        {
            _db.Add(vehicleMake);
            var numberOfCreated = await _db.SaveChangesAsync();
            return numberOfCreated;
        }

        public async Task<int> DeleteMakeAsync(int? id)
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

        public async Task<IEnumerable<VehicleMake>> GetAllMakesAsync(PagingParameters pagingParameters)
        {
            var pageSize = pagingParameters.pageSize;
            var pageNumber = pagingParameters.pageNumber;

            return await _db.VehicleMakes.Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<VehicleMake> GetMakeByIdAsync(int? id)
        {
            var vehicleMake = await _db.VehicleMakes.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception();
            }
            return vehicleMake;
        }

        public async Task<int> UpdateMakeAsync(VehicleMake vehicleMake)
        {
            _db.Update(vehicleMake);
            var numberOfChanges = await _db.SaveChangesAsync();

            return numberOfChanges;
        }
    }
}