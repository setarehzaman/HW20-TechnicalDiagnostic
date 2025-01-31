using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Service
{
    public interface IAdminService
    {
        Task<Admin>? GetById(int id, CancellationToken cancellation);
        Task<Admin>? GetByUsername(string username, CancellationToken cancellation);
        Admin GetByUsername(string username);
    }
}
