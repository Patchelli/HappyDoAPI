using HappyDo.Business.Handlers.PaginationSettings;
using HappyDo.Business.Interfaces.OthersContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Infrastructure.Services
{
    public sealed class PaginationQueryService<T> : IPaginationQueryService<T> where T : class
    {
        public async Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();

            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }

}
