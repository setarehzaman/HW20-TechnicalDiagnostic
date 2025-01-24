using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace App.Infrastructure.EFCore.Repositories
{
    public class VehicleModelRepository(AppDbContext context) : IVehicleModelRepository
    {
        public bool Create(VehicleModel vehicleModel)
        {
            context.Add(vehicleModel);
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var model = context.Models.First(x => x.Id == id);
            context.Remove(model);
            return context.SaveChanges() > 0;  
        }

        public List<VehicleModel> GetAll()
        {
            return context.Models.ToList();
        }

        public VehicleModel GetById(int id)
        {
            return context.Models.FirstOrDefault(x => x.Id == id);  
        }

        public bool Update(VehicleModel vehicleModel)
        {
            var exisitingModel = context.Models.FirstOrDefault(x => x.Id == vehicleModel.Id);
            exisitingModel.Name = vehicleModel.Name;
            exisitingModel.Id = vehicleModel.Id;
            return context.SaveChanges() > 0;
        }
    }
}
 