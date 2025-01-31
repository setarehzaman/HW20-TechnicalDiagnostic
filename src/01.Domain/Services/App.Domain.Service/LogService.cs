using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.Service
{
    public class LogService(ILogRepository logRepository) : ILogService
    {
        public async Task<Result> AddLog(Log log, CancellationToken cancellation)
        {
            return await logRepository.AddLog(log, cancellation);
        }
        public async Task<Log> GetLog(int id, CancellationToken cancellation)
        {
            return await logRepository.GetLog(id, cancellation);
        }
        public async Task<List<Log>> GetLogList(CancellationToken cancellation)
        {
            return await logRepository.GetLogList(cancellation);
        }
    }
}
