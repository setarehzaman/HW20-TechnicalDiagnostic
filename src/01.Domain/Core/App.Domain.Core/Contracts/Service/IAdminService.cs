using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IAdminService
    {
        Admin? GetById(int id);
        Admin? GetByUsername(string username);
        //bool Add(Admin user);
        //bool Delete(int id);
        //bool Update(Admin user);
        //List<Admin> GetAll();
    }
}
