using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Requests.LoggersRequest
{
    public sealed record UserLoggerRequest(ELoggerAction LoggerAction,
                                           DateTime ActionDate,
                                           string ExecutorRole,
                                           string ActionName,
                                           string? Reason,
                                           int UpdatedUserId,
                                           Guid ExecutorId);

}
