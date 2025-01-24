using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public class LogService(ILogRepository logRepository) : ILogService
    {
        public Result AddLog(Log log)
        {
            return logRepository.AddLog(log);
        }

        public Log GetLog(int id)
        {
            return logRepository.GetLog(id);
        }

        public List<Log> GetLogList()
        {
            return logRepository.GetLogList();
        }
    }
}
