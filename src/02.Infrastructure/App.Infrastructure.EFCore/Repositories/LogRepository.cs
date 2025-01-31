using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;


namespace App.Infrastructure.EFCore.Repositories
{
    public class LogRepository(AppDbContext context) : ILogRepository
    {
        public async Task<Result> AddLog(Log log, CancellationToken cancellationToken)
        {
            await context.Logs.AddAsync(log, cancellationToken);  
            await context.SaveChangesAsync(cancellationToken);  
            return new Result { IsSuccess = true };
        }

        public async Task<Log> GetLog(int id, CancellationToken cancellationToken)
        {
           return await context.Logs.FirstOrDefaultAsync(l => l.Id == id, cancellationToken); 
        }

        public async Task<List<Log>> GetLogList(CancellationToken cancellationToken)
        {
            return await context.Logs.ToListAsync(cancellationToken);   
        }
    }
}
