using HappyDo.ApplicationService.DataTransferObject.Requests.LoggersRequest;
using HappyDo.ApplicationService.Interfaces.ServicesContracts;
using HappyDo.Business.Interfaces.RepositoryContracts;
using HappyDo.Domain.Entities.ActionLoggerScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.Services.LoggersServices
{
    public sealed class UserLoggerFacadeService : IUserLoggerFacadeService
    {
        private readonly IUserLoggerRepository _userLoggerRepository;

        public UserLoggerFacadeService(IUserLoggerRepository userLoggerRepository)
        {
            _userLoggerRepository = userLoggerRepository;
        }


        public void Dispose() => _userLoggerRepository.Dispose();

        public Task<bool> CreateLoggerAsync(UserLoggerRequest userLoggerRequest)
        {
            var userLogger = new UserLogger()
            {
                ExecutorId = userLoggerRequest.ExecutorId,
                UpdatedUserId = userLoggerRequest.UpdatedUserId,
                ActionDate = userLoggerRequest.ActionDate,
                ActionName = userLoggerRequest.ActionName,
                ExecutorRole = userLoggerRequest.ExecutorRole,
                LoggerAction = userLoggerRequest.LoggerAction,
                Reason = userLoggerRequest.Reason
            };


            return _userLoggerRepository.SaveAsync(userLogger);
        }

    }

}
