using HappyDo.Infrastructure.ORM.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Infrastructure.Repository.Base
{
    public abstract class BaseRepository<T> : IDisposable where T : class
    {
        private readonly ApplicationContext _context;
        protected DbSet<T> DbSet => _context.Set<T>();

        protected BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        protected async Task<bool> SaveInDatabaseAsync() => await _context.SaveChangesAsync() > 0;

        protected void DetachedObject(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);
        }
    }

}
