using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.Pages
{
    public class ModelManagerModel(IVehicleModelAppService vehicleModelApp) : PageModel
    {
        public List<VehicleModel> VehicleModels { get; set; }
        public string ResultMessage { get; set; }
        public bool IsSuccess { get; set; }
        public async Task OnGet(CancellationToken cancellation)
        {
            VehicleModels = await vehicleModelApp.GetAllVehicleModels(cancellation);
        }

        public async Task<IActionResult> OnPostDelete(int id, CancellationToken cancellation)
        {
            var result = await vehicleModelApp.DeleteVehicleModel(id, cancellation);

            ResultMessage = result.Message;
            IsSuccess = result.IsSuccess;

            VehicleModels = await vehicleModelApp.GetAllVehicleModels(cancellation);
            return Page();
        }
    }
}



