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
        public void OnGet()
        {
            VehicleModels = vehicleModelApp.GetAllVehicleModels();
        }

        public IActionResult OnPostDelete(int id)
        {
            var result = vehicleModelApp.DeleteVehicleModel(id);

            ResultMessage = result.Message;
            IsSuccess = result.IsSuccess;

            VehicleModels = vehicleModelApp.GetAllVehicleModels();
            return Page();
        }
    }
}



