using FluentValidation;
using HappyDo.Business.Interfaces.OthersContracts;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyDo.Business.Extensions;

namespace HappyDo.Business.Handlers.ValidationSettings
{
    public abstract class Validate<T> : AbstractValidator<T>, IValidate<T> where T : class
    {
        private ValidationResult? _validationResult;

        private void CreateResult(T entity) => _validationResult ??= base.Validate(entity);

        private async Task CreateResultAsync(T entity) => _validationResult ??= await base.ValidateAsync(entity);

        private Dictionary<string, string> GetErrors() => _validationResult!.Errors.ToDictionary();


        public async Task<ValidationResponse> ValidationAsync(T entity)
        {
            await CreateResultAsync(entity);

            return ValidationResponse.CreateResponse(GetErrors());
        }

        public ValidationResponse Validation(T entity)
        {
            CreateResult(entity);

            return ValidationResponse.CreateResponse(GetErrors());
        }
    }

}
