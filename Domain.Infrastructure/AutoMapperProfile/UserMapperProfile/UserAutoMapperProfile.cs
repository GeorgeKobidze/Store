using AutoMapper;
using Domain.Infrastructure.DataTransferObjects.Request.User;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.AutoMapperProfile.UserMapperProfile
{
    public class UserAutoMapperProfile : Profile
    {
        public UserAutoMapperProfile()
        {
            CreateMap<RegisterUserDto, User>()
             .ForMember(c => c.LastModifiedDateTime, op => op.Ignore())
             .ForMember(c => c.CreatedDateTime, op => op.Ignore())
             .ForMember(c => c.Deleted, op => op.Ignore())
             .ForMember(c => c.UserRoles,op => op.Ignore())
             .ForSourceMember(c => c.UserRoles, op => op.DoNotValidate());
        }
    }
}
