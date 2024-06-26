﻿using HappyDo.Business.Handlers.PaginationSettings.PaginationFilters;
using HappyDo.Business.Handlers.PaginationSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyDo.ApplicationService.DataTransferObject.Responses.UserResponse;

namespace HappyDo.ApplicationService.Interfaces.ServicesContracts
{
    public interface IUserQueryService
    {
        Task<PageList<UserGridResponse>> FindAllUsersWithPaginationAsync(PagingParamsUserFilter pagingParams);
        Task<UserDataResponse?> FindByUserIdAsync(int userId);
    }

}
