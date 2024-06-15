using HappyDo.Domain.Entities.Categories;
using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Requests.Expense
{
    public sealed record ExpenseUpdateRequest
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public decimal Value { get; init; }
        public DateTime Date { get; init; }
        public int CategoryId { get; init; }
        public ESituation Situation { get; init; }
        public Guid ApplicationUserId { get; init; }
    }
}
