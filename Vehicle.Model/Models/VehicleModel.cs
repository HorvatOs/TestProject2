using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Vehicle.Model.Common.Interface;

namespace Vehicle.Model.Models
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public int MakeId { get; set; }

        public IVehicleMake VehicleMake { get; set; }
    }
}
