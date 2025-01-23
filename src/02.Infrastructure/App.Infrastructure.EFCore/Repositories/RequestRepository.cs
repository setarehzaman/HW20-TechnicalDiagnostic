using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;


namespace App.Infrastructure.EFCore.Repositories
{
    public class RequestRepository(AppDbContext context) : IRequestRepository
    {

        public bool Add(Request request)
        {
            context.Add(request);   
            return context.SaveChanges() > 0;
        }
        public bool UpdateRequestStatus(int requestId, string status)
        {
            var request = context.Requests.Find(requestId);
            if (request == null) return false;

            request.Status = status;
            return context.SaveChanges() > 0;
        }

        public List<Request> GetRequestsByDate(DateTime date)
        {
            return context.Requests
                           .Where(r => r.DateRequested.Date == date.Date)
                           .ToList();
        }

        public Request GetById(int id)
        {
            return context.Requests.FirstOrDefault(r => r.Id == id);
        }

        public List<Request> GetAll()
        {
            return context.Requests.ToList();   
        }
    }
}
