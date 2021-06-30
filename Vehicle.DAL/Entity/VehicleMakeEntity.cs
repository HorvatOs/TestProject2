using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Vehicle.DAL.Entity
{
    [Table("VehicleMakes")]
    public class VehicleMakeEntity
    {        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Abrv { get; set; }

        public ICollection<VehicleModelEntity> VehicleModels { get; set; }
    }
}
