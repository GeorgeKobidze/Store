using AutoMapper;
using Domain.Infrastructure.DataTransferObjects.Customer;
using Domain.Infrastructure.DataTransferObjects.Request.Customer;
using Domain.Infrastructure.DataTransferObjects.Response.Customer;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.AutoMapperProfile.CustomerMapperProfile
{
    public class CustomerAutoMapperProfile : Profile
    {

        public CustomerAutoMapperProfile()
        {
            CreateMap<RegisterCustomerDto, Customer>()
             .ForMember(c => c.LastModifiedDateTime, op => op.Ignore())
             .ForMember(c => c.CreatedDateTime, op => op.Ignore())
             .ForMember(c => c.Deleted, op => op.Ignore())
             .ForSourceMember(c => c.CustomerAddress, op => op.DoNotValidate());

            CreateMap<Customer, CustomerLoginInformationDto>()
                .ForSourceMember(c => c.CreatedDateTime, op => op.DoNotValidate())
                .ForSourceMember(c => c.LastModifiedDateTime, op => op.DoNotValidate())
                .ForSourceMember(c => c.Password, op => op.DoNotValidate())
                .ForSourceMember(c => c.CustomerAddresses, op => op.DoNotValidate())
                .ForSourceMember(c => c.Deleted, op => op.DoNotValidate());


            CreateMap<UpdateCustomerDto,Customer>()
                .ForMember(c => c.LastModifiedDateTime, op => op.Ignore())
                .ForMember(c => c.CreatedDateTime, op => op.Ignore())
                .ForMember(c => c.Deleted, op => op.Ignore())
                .ForMember(c => c.Password, op => op.Ignore())
                .ForSourceMember(c => c.CustomerAddress, op => op.DoNotValidate())
                .ForAllMembers(c => c.Condition((src, dest, srcMember) => srcMember != null)); 

        }
    }
}
