using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<User> GetById(int id, CancellationToken cancellationToken);
        Task<User> GetByUsernameAsync(string username, CancellationToken cancellationToken);
        User GetByUsername(string username);
    }

}
