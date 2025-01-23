
using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IVehicleAppService
    {
        Result AddVehicle(Vehicle vehicle);
        Result UpdateVehicle(Vehicle vehicle);
        Result DeleteVehicle(int id);
        List<Vehicle> GetAllVehicles();
        Vehicle GetVehicleById(int id);
    }                                                                     
}
