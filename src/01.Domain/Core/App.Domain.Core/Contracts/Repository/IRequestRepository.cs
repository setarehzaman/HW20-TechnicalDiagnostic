using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;


namespace App.Domain.Core.Contracts.Repository
{
    public interface IRequestRepository
    {
        Request GetById(int id);
        List<Request> GetAll();
        bool Add(Request request);
        bool UpdateRequestStatus(int requestId, string status);
        List<Request> GetRequestsByDate(DateTime date);
    }

}
