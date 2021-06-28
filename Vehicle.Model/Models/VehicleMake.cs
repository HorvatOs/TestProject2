using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Vehicle.Model.Common.Interface;

namespace Vehicle.Model.Models
{
    public class VehicleMake : IVehicleMake
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Abrv { get; set; }

        public ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}
