using HappyDo.Business.Handlers.ValidationSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Interfaces.OthersContracts
{
    public interface IValidate<T> where T : class
    {
        Task<ValidationResponse> ValidationAsync(T entity);
        ValidationResponse Validation(T entity);
    }

}
