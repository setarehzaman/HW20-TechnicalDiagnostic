using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IRequestService
    {
        Request GetById(int id);
        List<Request> GetAll();
        Result Add(Request request);
        bool Update(Request request);
        List<Request> GetRequestsByDate(DateTime date);
    }
}
