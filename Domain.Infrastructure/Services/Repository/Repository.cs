using Domain.Audit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Services
{
    public class Repository<T> : IRepository<T> where T : class, IAuditTable
    {
        private readonly DataBaseContext _dataBaseContext;

        public Repository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task Add(T entity)
        {
            await _dataBaseContext.AddAsync<T>(entity);
        }

        public async Task Add(IEnumerable<T> entities)
        {
            await _dataBaseContext.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            _dataBaseContext.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dataBaseContext.RemoveRange(entities);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _dataBaseContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(Guid Id)
        {
            return await _dataBaseContext.Set<T>().AsNoTracking().Where(e => !e.Deleted).SingleAsync(x => x.Uid == Id);
        }

        public void SoftDelete(T entity)
        {
            entity.LastModifiedDateTime = DateTime.Now;
            entity.Deleted = true;
            _dataBaseContext.Update(entity);
        }

        public void Update(T entity)
        {
            entity.LastModifiedDateTime = DateTime.Now;
            _dataBaseContext.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                item.LastModifiedDateTime = DateTime.Now;
            }
            _dataBaseContext.UpdateRange(entities);
        }


        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dataBaseContext.Set<T>().Where(e => !e.Deleted).Where<T>(expression);
        }

        public IQueryable<T> WhereOnDeleted(Expression<Func<T, bool>> expression)
        {
            return _dataBaseContext.Set<T>().Where(e => e.Deleted).Where<T>(expression);
        }
    }


}
