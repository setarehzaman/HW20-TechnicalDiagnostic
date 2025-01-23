using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using Microsoft.Extensions.Configuration;
using System.Net.Security;

namespace App.Domain.AppService
{
    public class RequestAppService(IRequestService requestService, IVehicleService vehicleService,
        IConfiguration configuration, ILogService logService) : IRequestAppService
    {      
        public Result SubmitRequest(Request request)
        {

            bool isOddDay = DateTime.Now.Day % 2 != 0;

            if ((request.Vehicle.Brand == "Iran Khodro" && isOddDay) ||
                (request.Vehicle.Brand == "Saipa" && !isOddDay))
            {
                return new Result { IsSuccess = false, Message = "در روز دیگری امتحان کنید" };
            }

            int maxRequests;
            if (isOddDay)
            {
                maxRequests = int.Parse(configuration["AppSettings:OddDayLimit"]);
            }
            else
            {
                maxRequests = int.Parse(configuration["AppSettings:EvenDayLimit"]);
            }

            int todayRequestsCount = requestService.GetRequestsByDate(DateTime.Today).Count;
            if (todayRequestsCount >= maxRequests)
                return new Result { IsSuccess = false, Message = "ثبت درخواست ها برای امروز به اتمام رسیده است" };


            if (DateTime.Now.Year - request.Vehicle.Year > 5)
            {
                logService.AddLog(new Log
                {
                    Id = request.Id,    
                    DateLogged = DateTime.Now,  
                    PlateNumber = request.Vehicle.PlateNumber
                });
                return new Result { IsSuccess = false, Message = "متاسفانه ماشین ماقبل سال 1398 در سامانه ثبت نمیشود"};
            }

            bool isAdded = requestService.Add(request).IsSuccess;
            if (!isAdded)
                return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };

            return new Result { IsSuccess = true, Message = "عملیات با موفقیت انجام شد" };
        }


    }
}
