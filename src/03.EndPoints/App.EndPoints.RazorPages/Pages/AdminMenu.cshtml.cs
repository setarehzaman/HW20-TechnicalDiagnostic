using App.Infrastructure.InMemoryDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.Pages
{
    public class AdminMenuModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPostLogout()
        {
            
            InMemoryDb.OnlineUser = null;

            return RedirectToPage("/AdminLogin");
        }

    }
}
