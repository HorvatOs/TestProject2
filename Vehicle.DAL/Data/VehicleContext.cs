using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.Model.Models;

namespace Vehicle.DAL.Data
{
    public class VehicleContext : DbContext
    {

        public VehicleContext(DbContextOptions<VehicleContext> options)
            : base(options)
        {

        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }

        public DbSet<VehicleModel> VehicleModels { get; set; }


    }
}
