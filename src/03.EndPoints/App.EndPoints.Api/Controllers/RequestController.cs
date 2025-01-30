using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController(IRequestAppService requestAppService) : ControllerBase
    {
        [HttpPost("Create")]
        public string CreateRequest(CreateRequestDto requestDto)
        {
            Request request = new Request();
            request.PlateNumber = requestDto.PlateNumber;
            request.VehicleCreationYear = requestDto.VehicleCreationYear;
            request.VehicleModelId = requestDto.VehicleModelId;
            request.Address = requestDto.Address;   
            request.Brand = requestDto.Brand;   
            request.MobileNumber = requestDto.MobileNumber;
            request.OwnerCode = requestDto.OwnerCode;
            request.Status = requestDto.Status;
            request.DateRequested = requestDto.DateRequested;   

            var result = requestAppService.SubmitRequest(request);
            if (result.IsSuccess)
            {
                return "عملیات با موفقیت انجام شد";
            }
            return "خطا";
            
        }
        [HttpGet("GetAll")]
        public List<Request> GetAllRequests()
        {
            var result = requestAppService.GetAllRequestsOrderedByDate();
            return result;
        }
    }
}
