using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.EFCore.Repositories
{
    public class VehicleRepository(AppDbContext context) : IVehicleRepository
    {


        public List<Vehicle> GetAll()
        {
            return context.Vehicles.ToList();
        }

        public Vehicle GetById(int id)
        {
            return context.Vehicles.FirstOrDefault(v => v.Id == id);        
        }
    }
}
