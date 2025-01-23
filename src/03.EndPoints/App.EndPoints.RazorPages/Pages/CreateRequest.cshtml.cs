using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities;

namespace App.EndPoints.RazorPages.Pages
{
    public class CreateRequestModel(IRequestAppService requestAppService, IVehicleModelAppService modelAppService) : PageModel
    {
        [BindProperty]
        public Request Request { get; set; }

        public List<VehicleModel> Models { get; set; }

        public string ResultMessage { get; private set; }
        public bool IsSuccess { get; private set; }

        public void OnGet()
        {
            Models = modelAppService.GetAllVehicleModels(); 
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Models = modelAppService.GetAllVehicleModels();
                return Page();
            }

            var result = requestAppService.SubmitRequest(Request);
            IsSuccess = result.IsSuccess;
            ResultMessage = result.Message;

            if (!IsSuccess)
            {
                Models = modelAppService.GetAllVehicleModels();
                return Page();
            }

            return RedirectToPage("RequestList");
        }
    }

}
