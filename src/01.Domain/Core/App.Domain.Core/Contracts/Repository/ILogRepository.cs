using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.Core.Contracts.Repository
{
    public interface ILogRepository
    {
        Result AddLog(Log log);
        List<Log> GetLogList();
        Log GetLog(int id);
    }

}
