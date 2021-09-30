using AutoMapper;
using Domain.Infrastructure.DataTransferObjects.Customer;
using Domain.Infrastructure.DataTransferObjects.Request.CustomerAddress;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.AutoMapperProfile.CustomerAddressMapperProfile
{
    public class CustomerAddressAutoMapperProfile : Profile
    {
        public CustomerAddressAutoMapperProfile()
        {
            CreateMap<RegisterCustomerAddressDto, CustomerAddress>()
             .ForMember(c => c.LastModifiedDateTime, op => op.Ignore())
             .ForMember(c => c.CreatedDateTime, op => op.Ignore())
             .ForMember(c => c.Customer, op => op.Ignore());

            CreateMap<UpdateCustomerAddressDto, CustomerAddress>()
            .ForMember(c => c.LastModifiedDateTime, op => op.Ignore())
            .ForMember(c => c.CreatedDateTime, op => op.Ignore())
            .ForMember(c => c.Customer, op => op.Ignore())
            .ForAllMembers(c => c.Condition((src, dest, srcMember) => srcMember != null)); 
        }

    }
}
