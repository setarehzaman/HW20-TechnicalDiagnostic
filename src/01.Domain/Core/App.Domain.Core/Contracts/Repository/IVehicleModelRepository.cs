using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IVehicleModelRepository
    {
        VehicleModel GetVehicleModel(int id);
        List<VehicleModel> GetAllVehicleModels();
        Result CreateVehicleModel(VehicleModel vehicleModel);
        Result UpdateVehicleModel(VehicleModel vehicleModel);
        Result DeleteVehicleModel(int id);
    }
}
