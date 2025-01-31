using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Service
{
    public interface IRequestService
    {
        Task<Request> GetById(int id, CancellationToken cancellation);
        Task<List<Request>> GetAll(CancellationToken cancellation);
        Task<Result> Add(Request request, CancellationToken cancellation);
        Task<bool> Update(Request request, CancellationToken cancellation);
        Task<List<Request>> GetRequestsByDate(DateTime date, CancellationToken cancellation);
    }
}
