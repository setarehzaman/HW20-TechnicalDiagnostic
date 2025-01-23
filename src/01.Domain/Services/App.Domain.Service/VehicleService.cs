using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public class VehicleService(IVehicleRepository vehicleRepository) : IVehicleService
    {
        public Result Add(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Result Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
