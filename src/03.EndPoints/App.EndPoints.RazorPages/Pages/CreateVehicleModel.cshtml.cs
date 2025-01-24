using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.Pages
{
    public class CreateVehicleModelModel(IVehicleModelAppService vehicleModelApp) : PageModel
    {  
        public string ResultMessage { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = false;
        public void OnGet()
        {
        } 
        public IActionResult OnPost(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                ResultMessage = "??? ??? ????????? ???? ????";
                IsSuccess = false;
                return Page();
            }

            var vehicleModel = new VehicleModel { Name = Name };

            var result = vehicleModelApp.CreateVehicleModel(vehicleModel);

            if (result.IsSuccess)
            {
                ResultMessage = result.Message;
                return Page();
            }
            ResultMessage = result.Message; 
            IsSuccess = result.IsSuccess;
            return Page();
        }
    }
}