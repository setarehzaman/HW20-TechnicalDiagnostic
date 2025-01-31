using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
    
namespace App.Domain.AppService
{
    public class UserAppService(IUserService UserService,
        UserManager<User> userManager, SignInManager<User> signInManager) : IUserAppService
    {
        public async Task<User> GetById(int id, CancellationToken cancellation)
        {
            return await UserService.GetById(id, cancellation);
        }
        public async Task<User> GetByUsername(string username, CancellationToken cancellation)
        {
            return await UserService.GetByUsername(username, cancellation);
        }
        public async Task<IdentityResult> Register(User user, CancellationToken cancellationToken)
        { 
            var result = await userManager.CreateAsync(user, user.Password);

            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }
        public async Task<IdentityResult> Login(string username, string password)
        {
            var result = await signInManager.PasswordSignInAsync(username, password, true, false);

            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }

    }
}
