
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.AppService
{
    public class LogAppService(ILogService logService) : ILogAppService
    {
        public Result AddLog(Log log)
        {
            return logService.AddLog(log);  
        }

        public Log GetLog(int id)
        {
            return logService.GetLog(id);
        }

        public List<Log> GetLogList()
        {
            return logService.GetLogList();
        }
    }
}
