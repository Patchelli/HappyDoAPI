using AutoMapper;
using HappyDo.ApplicationService.DataTransferObject.Responses.ApplicationRoleResponse;
using HappyDo.ApplicationService.DataTransferObject.Responses.Expense;
using HappyDo.Domain.Entities.Finance;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.AutoMapperSettings.EntitiesProfiles
{
    public sealed class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExpenseId));

        }
    }
}
