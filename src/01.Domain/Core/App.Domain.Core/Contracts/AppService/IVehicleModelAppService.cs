using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IVehicleModelAppService
    {
        //cw crud
        Task<VehicleModel> GetVehicleModel(int id, CancellationToken cancellationToken);
        Task<List<VehicleModel>> GetAllVehicleModels(CancellationToken cancellationToken);   
        Task<Result> CreateVehicleModel(VehicleModel vehicleModel, CancellationToken cancellationToken);
        Task<Result> UpdateVehicleModel(VehicleModel vehicleModel, CancellationToken cancellationToken);
        Task<Result> DeleteVehicleModel(int id, CancellationToken cancellationToken);

    }
}
