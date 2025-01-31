using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.Pages
{
    public class AdminMenuModel(SignInManager<User> signInManager) : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostLogout()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/Login"); 
        }
    }
}
