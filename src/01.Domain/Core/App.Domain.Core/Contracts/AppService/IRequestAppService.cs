using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IRequestAppService
    {
        Task<Result> SubmitRequest(Request request, CancellationToken cancellationToken);
        Task<List<Request>> GetAllRequestsOrderedByDate(CancellationToken cancellationToken);
        Task<Request> GetById(int id, CancellationToken cancellationToken);
        Task<Result> UpdateRequest(Request request, CancellationToken cancellationToken);
    }
}
