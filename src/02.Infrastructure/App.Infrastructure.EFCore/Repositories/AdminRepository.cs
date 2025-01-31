using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.Repositories
{
    public class AdminRepository(AppDbContext context) : IAdminRepository
    {
        public async Task<Admin?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Admins.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }
        public async Task<Admin?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await context.Admins.FirstOrDefaultAsync(a => a.Username == username,cancellationToken);
        }

        public Admin GetByUsername(string username)
        {
            return context.Admins.FirstOrDefault(a => a.Username == username);
        }
    }
}
