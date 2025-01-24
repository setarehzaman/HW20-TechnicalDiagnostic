using App.Domain.AppService;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
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

        public void OnGet()
        {
            Requests = requestAppService.GetAllRequestsOrderedByDate();
        }

        public IActionResult OnPostUpdateStatus(int RequestId, RequestStatusEnum NewStatus)
        {
            var request = requestAppService.GetById(RequestId);

            request.Status = NewStatus;

            bool isUpdated = requestAppService.UpdateRequest(request).IsSuccess;
            ResultMessage = requestAppService.UpdateRequest(request).Message;

            if (!isUpdated)
            {
                return Page();  
            }
            return RedirectToPage();
        }
        //public string GetStatusName(RequestStatusEnum status)
        //{
        //    switch (status)
        //    {
        //        case RequestStatusEnum.Approved:
        //            return "????? ???";
        //        case RequestStatusEnum.Rejected:
        //            return "?? ???";
        //        case RequestStatusEnum.Pending:
        //            return "?? ?????? ?????";
        //        default:
        //            return status.ToString(); 
        //    }
        //}

    }
}

