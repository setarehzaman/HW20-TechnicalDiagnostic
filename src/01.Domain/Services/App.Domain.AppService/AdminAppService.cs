using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;


namespace App.Domain.AppService
{
    public class AdminAppService(IAdminService adminService, IRequestService requestService) : IAdminAppService
    {
        public Admin GetById(int id)
        {
            return adminService.GetById(id);
        }

        public Admin GetByUsername(string username)
        {
            return adminService.GetByUsername(username);
        }

        public Result Login(string username, string password)
        {
            var admin = adminService.GetByUsername(username);
            if (admin == null) 
                return new Result { IsSuccess = false, Message = "این نام کاربری وجود ندارد" };
            else if (admin.Password == password) 
                return new Result { IsSuccess = true };
            else
                return new Result { IsSuccess = false , Message = "رمز عبور اشتباه است"};
        }

    }
}
