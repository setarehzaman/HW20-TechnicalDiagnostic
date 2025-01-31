using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IAdminAppService
    {
        Result Login(string username, string password);
        Task<Admin> GetById(int id, CancellationToken cancellationToken);
        Task<Admin> GetByUsername(string username, CancellationToken cancellationToken);
    }
}
