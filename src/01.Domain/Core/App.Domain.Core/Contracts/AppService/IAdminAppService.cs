using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IAdminAppService
    {
        Result Login(string username, string password);
        Admin GetById(int id);

        //List<Admin> GetAll();
        //Result CreateAdmin(Admin admin);
        //Result UpdateAdmin(Admin admin);
        //Result DeleteAdmin(int id);

    }
}
