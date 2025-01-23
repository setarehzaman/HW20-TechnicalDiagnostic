using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll(); 
        Vehicle GetById(int id);

    }

}
