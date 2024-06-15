using HappyDo.Domain.Entities.Categories;
using HappyDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Responses.Expense
{
    public sealed record ExpenseResponse
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public decimal Amount { get; init; }
        public DateTime Date { get; init; }
        public ESituation Situation { get; init; }
    }
}
