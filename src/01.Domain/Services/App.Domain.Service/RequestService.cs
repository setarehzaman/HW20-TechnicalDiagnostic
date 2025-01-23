using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetAll()
        {
            throw new NotImplementedException();
        }

        public Request GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetRequestsByDate(DateTime date)
        {
            return requestRepository.GetRequestsByDate(date);
        }

        public Result Update(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
