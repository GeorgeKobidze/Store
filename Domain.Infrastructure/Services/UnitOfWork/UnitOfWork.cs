using Domain.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Services.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IAuditTable
    {
        private readonly DataBaseContext _dataBaseContext;
        public IRepository<T> Repository { get; }

        public UnitOfWork(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
            Repository = new Repository<T>(_dataBaseContext);
        }

        public async Task CommitAsync()
        {

            await _dataBaseContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataBaseContext.Dispose();
        }
    }
}
