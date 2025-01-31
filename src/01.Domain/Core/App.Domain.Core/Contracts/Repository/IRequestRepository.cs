using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IRequestRepository
    {
        Task<Request> GetById(int id, CancellationToken cancellationToken);
        Task<List<Request>> GetAll(CancellationToken cancellationToken);
        Task Add(Request request, CancellationToken cancellation);
        Task<bool> Update(Request request, CancellationToken cancellation);
        Task<List<Request>> GetRequestsByDate(DateTime date , CancellationToken cancellation);
    }

}
