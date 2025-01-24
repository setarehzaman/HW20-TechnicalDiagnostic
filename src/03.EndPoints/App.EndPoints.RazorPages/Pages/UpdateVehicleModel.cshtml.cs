using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.Pages
{
    public class UpdateVehicleModelModel(IVehicleModelAppService vehicleModelApp) : PageModel
    {      
        [BindProperty]
        public VehicleModel VehicleModel { get; set; }
        public string ResultMessage { get; set; }
        public bool IsSuccess { get; set; }
        public IActionResult OnGet(int id)
        {
            VehicleModel = vehicleModelApp.GetVehicleModel(id);
            if (VehicleModel == null)
            {
                return RedirectToPage("/ModelManager");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            var result = vehicleModelApp.UpdateVehicleModel(VehicleModel);
            if (result.IsSuccess)
            {
                ResultMessage = result.Message;
                return RedirectToPage("/ModelManager");
            }
            ResultMessage = result.Message;
            IsSuccess = result.IsSuccess;
            return Page();
        }
    }
}