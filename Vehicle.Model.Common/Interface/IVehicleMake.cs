using System.Collections.Generic;

namespace Vehicle.Model.Common.Interface
{
    public interface IVehicleMake
    {

        int Id { get; set; }

        string Name { get; set; }

        string Abrv { get; set; }

        ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}
