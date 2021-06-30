using Microsoft.EntityFrameworkCore;
using Vehicle.DAL.Entity;
using Vehicle.Model.Models;

namespace Vehicle.DAL.Data
{
    public class VehicleContext : DbContext
    {

        public VehicleContext(DbContextOptions<VehicleContext> options)
            : base(options)
        {

        }

        public DbSet<VehicleMakeEntity> VehicleMakesEntity { get; set; }

        public DbSet<VehicleModelEntity> VehicleModelsEntity { get; set; }


    }
}
