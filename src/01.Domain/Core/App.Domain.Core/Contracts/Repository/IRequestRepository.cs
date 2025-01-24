using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IRequestRepository
    {
        Request GetById(int id);
        List<Request> GetAll();
        void Add(Request request);
        bool Update(Request request);
        List<Request> GetRequestsByDate(DateTime date);
    }

}
