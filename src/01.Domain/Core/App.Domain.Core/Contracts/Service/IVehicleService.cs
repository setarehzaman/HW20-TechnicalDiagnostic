using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IVehicleService
    {
        Result Add(Vehicle vehicle);
        Result Update(Vehicle vehicle);
        Result Delete(int id);
        List<Vehicle> GetAll();
        Vehicle GetById(int id);
    }
}
