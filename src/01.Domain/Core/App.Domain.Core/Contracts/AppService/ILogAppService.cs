using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.Core.Contracts.AppService
{
    public interface ILogAppService
    {
        Task<Result> AddLog(Log log, CancellationToken cancellationToken);
        Task<List<Log>> GetLogList(CancellationToken cancellationToken); 
        Task<Log> GetLog(int id, CancellationToken cancellationToken);  
    }
}
