using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Handlers.PaginationSettings.PaginationFilters
{
    public sealed class PagingParamsUserFilter : PagingParams
    {
        public string? Search { get; set; }
        public Guid? RoleId { get; set; }
        public EUserStatus? UserStatus { get; set; }
    }
}
