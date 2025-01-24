using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using App.Domain.Core.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IRequestAppService
    {
        Result SubmitRequest(Request request);
        List<Request> GetAllRequestsOrderedByDate();
        Request GetById(int id);
        Result UpdateRequest(Request request);
    }
}
