using FluentValidation;
using HappyDo.Business.Enums;
using HappyDo.Business.Extensions;
using HappyDo.Domain.Entities.Finance;

namespace HappyDo.Business.Handlers.ValidationSettings.EntityValidation
{
    public sealed class ExpenseValidation : Validate<Expense>
    {
        public ExpenseValidation()
        {
            SetRules();
        }

        private void SetRules()
        {
            RuleFor(expense => expense.Description)
                .NotEmpty()
                .Length(3, 150)
                .WithMessage(expense => string.IsNullOrWhiteSpace(expense.Description)
                    ? EMessage.Required.GetDescription().FormatTo("Descrição")
                    : EMessage.MoreExpected.GetDescription().FormatTo("Descrição", "entre {MinLength} e {MaxLength}"));

            RuleFor(expense => expense.Amount)
                .GreaterThan(0)
                .WithMessage(EMessage.GreatThanValue.GetDescription().FormatTo("Amount", "0"));

            RuleFor(expense => expense.ApplicationUserId)
                .NotEmpty()
                .WithMessage(EMessage.Required.GetDescription().FormatTo("Application User ID"));

            RuleFor(expense => expense.CategoryId)
                .NotNull()
                .WithMessage(EMessage.Required.GetDescription().FormatTo("Category"));

            RuleFor(expense => expense.Situation)
                .IsInEnum()
                .WithMessage(EMessage.Invalid.GetDescription().FormatTo("Situation"));
        }
    }
}
