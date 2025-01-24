using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.EFCore.Repositories
{
    public class LogRepository(AppDbContext context) : ILogRepository
    {
        public Result AddLog(Log log)
        {
            context.Logs.Add(log);  
            context.SaveChanges();  
            return new Result { IsSuccess = true };
        }

        public Log GetLog(int id)
        {
           return context.Logs.FirstOrDefault(l => l.Equals(id)); 
        }

        public List<Log> GetLogList()
        {
            return context.Logs.ToList();   
        }
    }
}
