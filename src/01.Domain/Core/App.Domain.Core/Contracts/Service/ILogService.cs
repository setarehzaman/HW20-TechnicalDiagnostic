using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;


namespace App.Domain.Core.Contracts.Service
{
    public interface ILogService
    {
        Task<Result> AddLog(Log log, CancellationToken cancellation);
        Task<List<Log>> GetLogList(CancellationToken cancellation);
        Task<Log> GetLog(int id, CancellationToken cancellation);
    }
}
