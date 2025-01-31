using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.Pages
{
    public class RegisterModel(IUserAppService userAppService) : PageModel
    {
        [BindProperty]
        public User User { get; set; } = new User();

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var result = await userAppService.Register(User, cancellationToken);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور معتبر نیست.");
                    return Page();
                }

                return RedirectToPage("/Login");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "خطا در انجام عملیات.");
                return Page();
            }
        }
    }
}