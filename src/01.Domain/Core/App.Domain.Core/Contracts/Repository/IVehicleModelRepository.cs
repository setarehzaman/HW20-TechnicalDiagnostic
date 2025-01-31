using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;


namespace App.Domain.Core.Contracts.Repository
{
    public interface IVehicleModelRepository
    {
        Task<VehicleModel> GetById(int id, CancellationToken cancellation);
        Task<List<VehicleModel>> GetAll(CancellationToken cancellation);
        Task<bool> Create(VehicleModel vehicleModel, CancellationToken cancellation);
        Task<bool> Update(VehicleModel vehicleModel, CancellationToken cancellation);
        Task<bool> Delete(int id, CancellationToken cancellation);
    }
}
