using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public class AdminService(IAdminRepository adminRepository) : IAdminService
    {
        public Admin? GetById(int id)
        {
           return adminRepository.GetById(id);
        }

        public Admin? GetByUsername(string username)
        {
            return adminRepository.GetByUsername(username);
        } 
    }
}
