using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.Service
{
    public class RequestService(IRequestRepository requestRepository) : IRequestService
    {
        public Result Add(Request request)
        {
            if (request == null) return new Result { IsSuccess = false };
            requestRepository.Add(request);  
            return new Result { IsSuccess = true };
        }

        public List<Request> GetAll()
        {
            return requestRepository.GetAll();  
        }

        public Request GetById(int id)
        {
            return requestRepository.GetById(id);   
        }

        public List<Request> GetRequestsByDate(DateTime date)
        {
            return requestRepository.GetRequestsByDate(date);
        }

        public bool Update(Request request)
        {
            return requestRepository.Update(request);
        }
    }
}
