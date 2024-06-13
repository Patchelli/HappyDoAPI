using AutoMapper;
using HappyDo.ApplicationService.DataTransferObject.Responses.ApplicationRoleResponse;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.AutoMapperSettings.EntitiesProfiles
{
    public sealed class ApplicationRoleProfile : Profile
    {
        public ApplicationRoleProfile()
        {
            CreateMap<ApplicationRole, ApplicationRoleSimpleResponse>()
                .ForMember(dest => dest.ApplicationRoleId, sourc => sourc.MapFrom(ar => ar.Id))
                .ForMember(dest => dest.RoleName, sourc => sourc.MapFrom(ar => ar.Name))
                ;
        }
    }

}
