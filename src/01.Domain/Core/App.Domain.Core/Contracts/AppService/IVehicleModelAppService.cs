using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IVehicleModelAppService
    {
        //cw crud
        VehicleModel GetVehicleModel(int id);
        List<VehicleModel> GetAllVehicleModels();   
        Result CreateVehicleModel(VehicleModel vehicleModel);
        Result UpdateVehicleModel(VehicleModel vehicleModel);
        Result DeleteVehicleModel(int id);

    }
}
