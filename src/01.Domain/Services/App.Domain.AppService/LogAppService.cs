
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.AppService
{
    public class LogAppService(ILogService logService) : ILogAppService
    {
        public async Task<Result> AddLog(Log log, CancellationToken cancellationToken)
        {
            return await logService.AddLog(log, cancellationToken);  
        }

        public async Task<Log> GetLog(int id, CancellationToken cancellationToken)
        {
            return await logService.GetLog(id, cancellationToken);
        }

        public async Task<List<Log>> GetLogList(CancellationToken cancellationToken)
        {
            return await logService.GetLogList(cancellationToken);
        }
    }
}
