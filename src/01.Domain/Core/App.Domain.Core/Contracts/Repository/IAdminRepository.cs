using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IAdminRepository
    {
        Task<Admin> GetById(int id, CancellationToken cancellationToken);
        Task<Admin> GetByUsernameAsync(string username, CancellationToken cancellationToken);
        Admin GetByUsername(string username);
    }

}
