using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.Service
{
    public class RequestService(IRequestRepository requestRepository) : IRequestService
    {
        public async Task<Result> Add(Request request, CancellationToken cancellation)
        {
            if (request == null) return new Result { IsSuccess = false };
            await requestRepository.Add(request, cancellation);
            return new Result { IsSuccess = true };
        }

        public async Task<List<Request>> GetAll(CancellationToken cancellation)
        {
            return await requestRepository.GetAll(cancellation);
        }

        public async Task<Request> GetById(int id, CancellationToken cancellation)
        {
            return await requestRepository.GetById(id, cancellation);
        }

        public async Task<List<Request>> GetRequestsByDate(DateTime date, CancellationToken cancellation)
        {
            return await requestRepository.GetRequestsByDate(date, cancellation);
        }

        public async Task<bool> Update(Request request, CancellationToken cancellation)
        {
            return await requestRepository.Update(request, cancellation);
        }
    }
}
