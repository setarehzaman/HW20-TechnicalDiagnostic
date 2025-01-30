
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using Microsoft.Extensions.Configuration;


namespace App.Domain.AppService
{
    public class RequestAppService(IRequestService requestService,
        IConfiguration configuration, ILogService logService) : IRequestAppService
    {
        public Result SubmitRequest(Request request)
        {

            bool isOddDay = request.DateRequested.Day % 2 != 0;

            if ((request.Brand == "ایران خودرو" && isOddDay) |
                (request.Brand == "سایپا" && !isOddDay))
            {
                return new Result { IsSuccess = false, Message = " روز دیگری را امتحان کنید" };
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


            if (DateTime.Now.Year - request.VehicleCreationYear > 5)
            {
                logService.AddLog(new Log
                {
                    Id = request.Id,
                    DateLogged = DateTime.Now,
                    PlateNumber = request.PlateNumber
                });
                return new Result { IsSuccess = false, Message = "متاسفانه ماشین ماقبل سال 1398 در سامانه ثبت نمیشود" };
            }


            bool isAdded = requestService.Add(request).IsSuccess;
            if (!isAdded)
                return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };

            return new Result { IsSuccess = true, Message = "عملیات با موفقیت انجام شد" };
        }

        public List<Request> GetAllRequestsOrderedByDate()
        {
            return requestService.GetAll()
                .OrderByDescending(r => r.DateRequested)
                .ToList();
        }
        public Request GetById(int id)
        {
            return requestService.GetById(id);
        }

        public Result UpdateRequest(Request request)
        {
            if (request == null)
            {
                return new Result { IsSuccess = false, Message = "درخواست مورد نظر یافت نشد." };
            }
            if (requestService.Update(request))
            {
                return new Result { IsSuccess = true, Message = "عملیات با موفقیت انجام شد" };
            }
            return new Result { IsSuccess = false, Message = "متاسفانه در ثبت اطلاعات خطایی رخ داده" };
        }

    }
}