using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;

namespace App.Domain.Service
{
    public class VehicleModelService(IVehicleModelRepository modelRepository) : IVehicleModelService
    {
        public async Task<bool> Create(VehicleModel vehicleModel, CancellationToken cancellation)
        {
            return await modelRepository.Create(vehicleModel, cancellation);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellation)
        {
            return await modelRepository.Delete(id, cancellation);
        }

        public async Task<List<VehicleModel>> GetAll(CancellationToken cancellation)
        {
            return await modelRepository.GetAll(cancellation);
        }

        public async Task<VehicleModel> GetById(int id, CancellationToken cancellation)
        {
            return await modelRepository.GetById(id, cancellation);
        }

        public async Task<bool> Update(VehicleModel vehicleModel, CancellationToken cancellation)
        {
            return await modelRepository.Update(vehicleModel, cancellation);
        }
    }
}
