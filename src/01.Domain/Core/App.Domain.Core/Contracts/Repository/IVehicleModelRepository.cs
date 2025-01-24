using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;


namespace App.Domain.Core.Contracts.Repository
{
    public interface IVehicleModelRepository
    {
        VehicleModel GetById(int id);
        List<VehicleModel> GetAll();
        bool Create(VehicleModel vehicleModel);
        bool Update(VehicleModel vehicleModel);
        bool Delete(int id);
    }
}
