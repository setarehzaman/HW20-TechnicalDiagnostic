using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.EFCore.Repositories
{
    public class AdminRepository(AppDbContext context) : IAdminRepository
    {
        public Admin? GetById(int id)
        {
            return context.Admins.FirstOrDefault(a => a.Id == id);   
        }

        public Admin? GetByUsername(string username)
        {
            return context.Admins.FirstOrDefault( a => a.Username == username);  
        }
    }
}
