using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface ILogService
    {
        Result AddLog(Log log);
        List<Log> GetLogList();
        Result GetLog(int id);
    }
}
