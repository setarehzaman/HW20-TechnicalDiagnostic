using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface ILogAppService
    {
        Result AddLog(Log log);
        List<Log> GetLogList(); 
        Log GetLog(int id);  
    }
}
