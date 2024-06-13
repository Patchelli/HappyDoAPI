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
    public sealed class ApplicationUserValidation : Validate<ApplicationUser>
    {
        public ApplicationUserValidation()
        {
            SetRules();
        }

        private void SetRules()
        {
            RuleFor(a => a.User).SetValidator(new UserValidation()!);

            RuleFor(a => a.UserName).EmailAddress()
                                    .Length(7, 150)
                                    .WithMessage(a => !string.IsNullOrWhiteSpace(a.UserName)
                                    ? EMessage.MoreExpected.GetDescription().FormatTo("Login", "entre {MinLength} e {MaxLength}")
                                    : EMessage.Required.GetDescription().FormatTo("Login"));


            When(a => a.Id != Guid.Empty, () =>
            {
                RuleFor(a => a.PasswordHash).Length(6, 20)
                                            .Must(password => password.ValidatePassword())
                                            .WithMessage("A senha não atende aos requisitos.");
            });
        }
    }

}
