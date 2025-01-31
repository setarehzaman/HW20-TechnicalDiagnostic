using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace App.Infrastructure.EFCore.Repositories
{
    public class VehicleModelRepository(AppDbContext context) : IVehicleModelRepository
    {
        public async Task<bool> Create(VehicleModel vehicleModel, CancellationToken cancellationToken)
        {
            await context.AddAsync(vehicleModel, cancellationToken);
            var changes = await context.SaveChangesAsync(cancellationToken);
            if(changes > 0) return true;
            return false;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var model = await context.Models.FirstOrDefaultAsync(x => x.Id == id);
            context.Remove(model);
            var changes = await context.SaveChangesAsync(cancellationToken);
            if (changes > 0) return true;
            return false;
        }

        public async Task<List<VehicleModel>> GetAll(CancellationToken cancellationToken)
        {
            return await context.Models.ToListAsync(cancellationToken);
        }

        public async Task<VehicleModel> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Models.FirstOrDefaultAsync(x => x.Id == id);  
        }

        public async Task<bool> Update(VehicleModel vehicleModel, CancellationToken cancellation)
        {
            var exisitingModel = context.Models.FirstOrDefault(x => x.Id == vehicleModel.Id);

            exisitingModel.Name = vehicleModel.Name;
            exisitingModel.Id = vehicleModel.Id;

            var changes = await context.SaveChangesAsync(cancellation);
            if (changes > 0) return true;
            return false;
        }
    }
}
 