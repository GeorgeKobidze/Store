using Domain.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Services.UnitOfWork
{
    public interface IUnitOfWork<T> : IDisposable where T : class, IAuditTable
    {
        IRepository<T> Repository { get; }

        Task CommitAsync();
    }
}
