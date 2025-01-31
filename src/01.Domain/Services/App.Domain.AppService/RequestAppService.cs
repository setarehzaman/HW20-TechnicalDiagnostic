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
        public async Task<Result> SubmitRequest(Request request, CancellationToken cancellationToken)
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
            var todayRequests = await requestService.GetRequestsByDate(DateTime.Today, cancellationToken);
            int todayRequestsCount = todayRequests.Count;
            if (todayRequestsCount >= maxRequests)
                return new Result { IsSuccess = false, Message = "ثبت درخواست ها برای امروز به اتمام رسیده است" };

            if (DateTime.Now.Year - request.VehicleCreationYear > 5)
            {
                var log = new Log
                {
                    Id = request.Id,
                    DateLogged = DateTime.Now,
                    PlateNumber = request.PlateNumber
                };
                await logService.AddLog(log, cancellationToken);

                return new Result { IsSuccess = false, Message = "متاسفانه ماشین ماقبل سال 1398 در سامانه ثبت نمیشود" };
            }

            var result = await requestService.Add(request, cancellationToken);
            bool isAdded = result.IsSuccess;
            if (!isAdded)
                return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };

            return new Result { IsSuccess = true, Message = "عملیات با موفقیت انجام شد" };
        }

        public async Task<List<Request>> GetAllRequestsOrderedByDate(CancellationToken cancellationToken)
        {
            var requests = await requestService.GetAll(cancellationToken); 
            return requests.OrderByDescending(r => r.DateRequested).ToList(); 
        }

        public async Task<Request> GetById(int id, CancellationToken cancellationToken)
        {
            return await requestService.GetById(id, cancellationToken);
        }

        public async Task<Result> UpdateRequest(Request request,CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new Result { IsSuccess = false, Message = "درخواست مورد نظر یافت نشد." };
            }
            if (await requestService.Update(request, cancellationToken))
            {
                return new Result { IsSuccess = true, Message = "عملیات با موفقیت انجام شد" };
            }
            return new Result { IsSuccess = false, Message = "متاسفانه در ثبت اطلاعات خطایی رخ داده" };
        }

    }
}