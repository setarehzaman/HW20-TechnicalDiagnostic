using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.enums;

namespace App.Infrastructure.EFCore.Repositories
{
    public class RequestRepository(AppDbContext context) : IRequestRepository
    {

        public void Add(Request request)
        {
            context.Add(request);
            context.SaveChanges();
        }

        public bool Update(Request request)
        {
            context.Update(request);
            return context.SaveChanges() > 0;
        }

        public List<Request> GetRequestsByDate(DateTime date)
        {
            return context.Requests
                           .Where(r => r.DateRequested.Date.Day == date.Date.Day)
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
