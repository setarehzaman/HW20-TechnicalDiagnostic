using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.Repositories
{
    public class RequestRepository(AppDbContext context) : IRequestRepository
    {

        public async Task Add(Request request, CancellationToken cancellationToken)
        {
            await context.AddAsync(request, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> Update(Request request, CancellationToken cancellationToken)
        {
            context.Update(request);
            var changes = await context.SaveChangesAsync(cancellationToken);
            if (changes > 0) return true;
            return false;
        }
        public async Task<List<Request>> GetRequestsByDate(DateTime date, CancellationToken cancellationToken)
        {
            return await context.Requests
                           .Where(r => r.DateRequested.Date.Day == date.Date.Day)
                           .ToListAsync(cancellationToken);
        }

        public async Task<Request> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Requests.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Request>> GetAll(CancellationToken cancellationToken)
        {
            return await context.Requests.ToListAsync(cancellationToken);
        }
    }
}
