

using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.Service
{
    public class VehicleModelService(IVehicleModelRepository modelRepository) : IVehicleModelService
    {
        public Result CreateVehicleModel(VehicleModel vehicleModel)
        {
            return modelRepository.CreateVehicleModel(vehicleModel);
        }

        public Result DeleteVehicleModel(int id)
        {
            return modelRepository.DeleteVehicleModel(id);
        }

        public List<VehicleModel> GetAllVehicleModels()
        {
            return modelRepository.GetAllVehicleModels();
        }

        public VehicleModel GetVehicleModel(int id)
        {
            return modelRepository.GetVehicleModel(id);
        }

        public Result UpdateVehicleModel(VehicleModel vehicleModel)
        {
            return modelRepository.UpdateVehicleModel(vehicleModel);    
        }
    }
}
