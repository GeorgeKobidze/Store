using AutoMapper;
using Domain.Infrastructure.AutoMapperProfile.CategoryMapperProfile;
using Domain.Infrastructure.AutoMapperProfile.CustomerAddressMapperProfile;
using Domain.Infrastructure.AutoMapperProfile.CustomerMapperProfile;
using Domain.Infrastructure.AutoMapperProfile.ProductMapperProfile;
using Domain.Infrastructure.AutoMapperProfile.UserMapperProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.AutoMapperProfile
{
    public class AutoMappersProfile : Profile
    {
        public AutoMappersProfile()
        {
            new CustomerAddressAutoMapperProfile();
            new CustomerAutoMapperProfile();
            new UserAutoMapperProfile();
            new CategoryAutoMapperProfile();
            new ProductAutoMapperProfile();
        }
    }
}
