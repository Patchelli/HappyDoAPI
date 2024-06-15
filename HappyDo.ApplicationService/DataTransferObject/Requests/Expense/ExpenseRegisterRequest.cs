using HappyDo.Domain.Enums;
using System;

namespace HappyDo.ApplicationService.DataTransferObject.Requests.Expense
{
    public sealed record ExpenseRegisterRequest
    {
        public string Description { get; init; }
        public decimal Value { get; init; }
        public DateTime Date { get; init; }
        public int CategoryId { get; init; } 
        public ESituation Situation { get; init; } 
        public Guid ApplicationUserId { get; init; }
    }
}
