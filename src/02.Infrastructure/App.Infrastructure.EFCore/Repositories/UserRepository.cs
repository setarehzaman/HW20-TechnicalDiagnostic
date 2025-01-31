using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<User?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Users.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }
        public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await context.Users.FirstOrDefaultAsync(a => a.UserName == username,cancellationToken);
        }

        public User GetByUsername(string username)
        {
            return context.Users.FirstOrDefault(a => a.UserName == username);
        }
    }
}
