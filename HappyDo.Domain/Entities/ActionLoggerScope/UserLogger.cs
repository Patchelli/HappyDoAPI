using HappyDo.Domain.Entities.UserScope;
using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Entities.ActionLoggerScope
{
    public sealed class UserLogger
    {
        public long UserLoggerId { get; init; }
        public required ELoggerAction LoggerAction { get; init; }
        public required DateTime ActionDate { get; init; }
        public required string ExecutorRole { get; init; }
        public required string ActionName { get; init; }
        public string? Reason { get; init; }

        public int UpdatedUserId { get; init; }
        public required Guid ExecutorId { get; init; }
        public ApplicationUser? Executor { get; init; }
    }

}
