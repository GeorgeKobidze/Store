using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.DataTransferObjects.Request.CustomerAddress;
using Domain.Model;

namespace Domain.Application.Services.CustomerAddresses
{
    public interface ICustomerAddressService
    {
        Task RegisterAdress(CustomerAddress customerAddress);

        Task UpdateAdress(UpdateCustomerAddressDto updateCustomerAddressDto, Customer customer);

    }
}
