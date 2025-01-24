using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;

namespace App.Domain.Service
{
    public class VehicleModelService(IVehicleModelRepository modelRepository) : IVehicleModelService
    {
        public bool Create(VehicleModel vehicleModel)
        {
            return modelRepository.Create(vehicleModel);    
        }

        public bool Delete(int id)
        {
            return modelRepository.Delete(id);
        }

        public List<VehicleModel> GetAll()
        {
            return modelRepository.GetAll();
        }

        public VehicleModel GetById(int id)
        {
            return modelRepository.GetById(id);
        }

        public bool Update(VehicleModel vehicleModel)
        {
            return modelRepository.Update(vehicleModel);        
        }
    }
}
