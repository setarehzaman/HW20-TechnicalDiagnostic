using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Service;
using App.Infrastructure.InMemoryDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.Pages
{
    public class AdminLoginModel(IAdminAppService adminAppService) : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var result = adminAppService.Login(Username, Password);

            if (result.IsSuccess)
            {
                InMemoryDb.OnlineUser = adminAppService.GetByUsername(Username);
                return RedirectToPage("/AdminMenu");  
            }
            ErrorMessage = result.Message;
            return Page();
        }
    }
}
   
