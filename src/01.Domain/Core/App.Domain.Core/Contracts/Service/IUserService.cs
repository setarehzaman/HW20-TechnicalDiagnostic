using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Service
{
    public interface IUserService
    {
        Task<User>? GetById(int id, CancellationToken cancellation);
        Task<User>? GetByUsername(string username, CancellationToken cancellation);
        User GetByUsername(string username);
    }
}
