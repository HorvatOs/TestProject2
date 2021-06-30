using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Vehicle.DAL.Entity
{
    [Table("VehicleModels")]
    public class VehicleModelEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Abrv { get; set; }

        public int MakeId { get; set; }

        [ForeignKey("MakeId")]
        public VehicleMakeEntity VehicleMake { get; set; }
    }
}
