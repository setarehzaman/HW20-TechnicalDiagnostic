using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;


namespace App.Domain.Core.Contracts.Service
{
    public interface IVehicleModelService
    {
        VehicleModel GetVehicleModel(int id);
        List<VehicleModel> GetAllVehicleModels();
        Result CreateVehicleModel(VehicleModel vehicleModel);
        Result UpdateVehicleModel(VehicleModel vehicleModel);
        Result DeleteVehicleModel(int id);
    }
}
