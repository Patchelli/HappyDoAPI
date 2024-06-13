using HappyDo.ApplicationService.DataTransferObject.Requests.LoggersRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Interfaces.ServicesContracts
{
    public interface IUserLoggerFacadeService : IDisposable
    {
        Task<bool> CreateLoggerAsync(UserLoggerRequest userLoggerRequest);
    }

}
