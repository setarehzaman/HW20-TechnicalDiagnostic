using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IAdminRepository
    {
        Admin? GetById(int id);
        Admin? GetByUsername(string username);
    }

}
