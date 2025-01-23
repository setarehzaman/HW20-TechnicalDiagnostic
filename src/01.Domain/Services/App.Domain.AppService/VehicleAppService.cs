using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.AppService
{
    public class VehicleAppService(IVehicleService vehicleService) : IVehicleAppService
    {
        public Result AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Result DeleteVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        public Result UpdateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
