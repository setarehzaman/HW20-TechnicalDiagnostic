using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.AppService
{
    public class VehicleModelAppService(IVehicleModelService modelService) : IVehicleModelAppService
    {
        public Result CreateVehicleModel(VehicleModel vehicleModel)
        {
            return modelService.CreateVehicleModel(vehicleModel);   
        }

        public Result DeleteVehicleModel(int id)
        {
            return modelService.DeleteVehicleModel(id);
        }

        public List<VehicleModel> GetAllVehicleModels()
        {
            return modelService.GetAllVehicleModels();
        }

        public VehicleModel GetVehicleModel(int id)
        {
            return modelService.GetVehicleModel(id);
        }

        public Result UpdateVehicleModel(VehicleModel vehicleModel)
        {
            return modelService.UpdateVehicleModel(vehicleModel);
        }
    }
}
