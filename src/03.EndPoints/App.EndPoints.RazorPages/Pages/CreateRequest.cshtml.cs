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
        [BindProperty]
        public List<VehicleModel> Models { get; set; }

        public string ResultMessage { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = false;

        public async Task OnGet(CancellationToken cancellation)
        {
            Models = await modelAppService.GetAllVehicleModels(cancellation); 
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellation)
        {
            var result = await requestAppService.SubmitRequest(Request, cancellation);
            IsSuccess = result.IsSuccess;
            ResultMessage = result.Message;

            return RedirectToPage("/CreateRequest");
        }
    }
}
