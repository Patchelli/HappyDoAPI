using HappyDo.Business.Handlers.PaginationSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Interfaces.OthersContracts
{
    public interface IPaginationQueryService<T> where T : class
    {
        Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber);
    }

}
