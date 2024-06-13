using AutoMapper;
using HappyDo.ApplicationService.DataTransferObject.Responses.UserResponse;
using HappyDo.Business.Handlers.PaginationSettings;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.AutoMapperSettings.EntitiesProfiles
{
    public sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGridResponse>()
                .ForPath(dest => dest.RoleName, source => source.MapFrom(
                    ur => ur.ApplicationUser!.UserRoles!.FirstOrDefault()!.Role!.Name));


            CreateMap<User, UserDataResponse>()
                .ForPath(dest => dest.UserLogin, source => source.MapFrom(u => u.ApplicationUser!.UserName))
                .ForPath(dest => dest.RoleName, source => source.MapFrom(
                    u => u.ApplicationUser!.UserRoles.FirstOrDefault()!.Role!.Name))
                .ForPath(dest => dest.RoleId, source => source.MapFrom(
                    u => u.ApplicationUser!.UserRoles.FirstOrDefault()!.Role!.Id));

            CreateMap<PageList<User>, PageList<UserGridResponse>>();
        }
    }

}
