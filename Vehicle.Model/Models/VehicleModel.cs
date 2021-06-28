﻿using System;
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

        [Required]
        public string Name { get; set; }

        public string Abrv { get; set; }

        public int MakeId { get; set; }

        [ForeignKey("MakeId")]
        public VehicleMake VehicleMake { get; set; }
        IVehicleMake IVehicleModel.VehicleMake { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
