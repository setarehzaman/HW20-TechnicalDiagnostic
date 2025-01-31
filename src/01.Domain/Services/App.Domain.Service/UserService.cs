using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;

namespace App.Domain.Service
{
    public class UserService(IUserRepository UserRepository) : IUserService
    {
        public async Task<User>? GetById(int id, CancellationToken cancellationToken)
        {
           return await UserRepository.GetById(id, cancellationToken);
        }
        public User? GetByUsername(string username)
        {
            return UserRepository.GetByUsername(username);
        }
        public async Task<User>? GetByUsername(string username, CancellationToken cancellation)
        {
            return await UserRepository.GetByUsernameAsync(username, cancellation);
        }
    }
}
