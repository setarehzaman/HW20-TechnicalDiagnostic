using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;

namespace App.Domain.Service
{
    public class AdminService(IAdminRepository adminRepository) : IAdminService
    {
        public async Task<Admin>? GetById(int id, CancellationToken cancellationToken)
        {
           return await adminRepository.GetById(id, cancellationToken);
        }
        public Admin? GetByUsername(string username)
        {
            return adminRepository.GetByUsername(username);
        }
        public async Task<Admin>? GetByUsername(string username, CancellationToken cancellation)
        {
            return await adminRepository.GetByUsernameAsync(username, cancellation);
        }
    }
}
