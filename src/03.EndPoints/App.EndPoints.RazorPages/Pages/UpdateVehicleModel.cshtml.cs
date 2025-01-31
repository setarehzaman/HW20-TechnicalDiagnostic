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
        public async Task<IActionResult> OnGet(int id, CancellationToken cancellationToken)
        {
            VehicleModel = await vehicleModelApp.GetVehicleModel(id, cancellationToken);
            if (VehicleModel == null)
            {
                return RedirectToPage("/ModelManager");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellation)
        {
            var result = await vehicleModelApp.UpdateVehicleModel(VehicleModel, cancellation);
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