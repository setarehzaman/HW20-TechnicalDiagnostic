using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities;
using App.Domain.Core.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.Pages
{
    public class ManagingRequestsModel(IRequestAppService requestAppService) : PageModel
    {
        [BindProperty]
        public List<Request> Requests { get; set; }
        public string ResultMessage { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = false;

        public async Task OnGet(CancellationToken cancellation)
        {
            Requests = await requestAppService.GetAllRequestsOrderedByDate(cancellation);
        }

        public async Task<IActionResult> OnPostUpdateStatus(int RequestId, RequestStatusEnum NewStatus, CancellationToken cancellation)
        {
            var request = await requestAppService.GetById(RequestId, cancellation);

            request.Status = NewStatus;

            var updateResult = await requestAppService.UpdateRequest(request, cancellation);
            bool isUpdated = updateResult.IsSuccess;
            ResultMessage = updateResult.Message;

            if (!isUpdated)
            {
                return Page();
            }
            return RedirectToPage();
        }
    }
}

