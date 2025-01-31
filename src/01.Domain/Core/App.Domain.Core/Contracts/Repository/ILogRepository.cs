using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.Core.Contracts.Repository
{
    public interface ILogRepository
    {
        Task<Result> AddLog(Log log, CancellationToken cancellation);
        Task<List<Log>> GetLogList(CancellationToken cancellationToken);
        Task<Log> GetLog(int id, CancellationToken cancellationToken);
    }

}
