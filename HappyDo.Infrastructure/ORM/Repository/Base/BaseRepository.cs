using HappyDo.Infrastructure.ORM.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Infrastructure.ORM.Repository.Base
{

    public abstract class BaseRepository<T> : IDisposable where T : class
    {
        private readonly ApplicationContext _dbContext;

        protected BaseRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        protected DbSet<T> DbSetContext => _dbContext.Set<T>();

        protected async Task<bool> SaveInDatabaseAsync() =>
            await _dbContext.SaveChangesAsync() > 0;

        protected void DetachedObject(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
                DbSetContext.Attach(entity);
        }
    }
}
