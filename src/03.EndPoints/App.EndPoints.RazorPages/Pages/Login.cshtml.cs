using App.Domain.Core.Contracts.AppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.RazorPages.Pages
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]
        public string Username { get; set; }

        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        public string Password { get; set; }
    }

    public class LoginModel(IUserAppService userAppService) : PageModel
    {

        [BindProperty]
        public LoginRequest LoginRequest { get; set; } = new LoginRequest();

        public string ResultMessage { get; set; }
        public bool IsSuccess { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await userAppService.Login(LoginRequest.Username, LoginRequest.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور اشتباه است.");
                return Page();
            }

            return RedirectToPage("/AdminMenu");
        }
    }
}

