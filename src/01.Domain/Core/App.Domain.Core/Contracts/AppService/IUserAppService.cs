using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IUserAppService
    {
        Task<User> GetById(int id, CancellationToken cancellationToken);
        Task<User> GetByUsername(string username, CancellationToken cancellationToken);
        Task<IdentityResult> Register(User user, CancellationToken cancellationToken);
        Task<IdentityResult> Login(string username, string password);

    }
}
