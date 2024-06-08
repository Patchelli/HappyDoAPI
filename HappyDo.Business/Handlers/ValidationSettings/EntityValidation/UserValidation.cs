using FluentValidation;
using HappyDo.Business.Enums;
using HappyDo.Business.Extensions;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Handlers.ValidationSettings.EntityValidation
{
    public sealed class UserValidation : Validate<User>
    {
        public UserValidation()
        {
            SetRules();
        }

        private void SetRules()
        {

            RuleFor(u => u.UserStatus).IsInEnum()
                                      .WithMessage(EMessage.InvalidValue.GetDescription().FormatTo("Tipo de usuaio"));

            RuleFor(u => u.Name).NotEmpty()
                                .Length(3, 150)
                                .WithMessage(u => string.IsNullOrWhiteSpace(u.Name)
                                ? EMessage.Required.GetDescription().FormatTo("Nome")
                                : EMessage.MoreExpected.GetDescription().FormatTo("Nome", "entre {MinLength} e {MaxLength}"));

        }
    }

}
