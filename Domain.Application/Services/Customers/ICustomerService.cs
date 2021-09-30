using Domain.Infrastructure.DataTransferObjects.Customer;
using Domain.Infrastructure.DataTransferObjects.Request.Customer;
using Domain.Infrastructure.DataTransferObjects.Response.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Customers
{
    public interface ICustomerService
    {
        Task RegisterCustomer(RegisterCustomerDto registerCustomer);
        Task<CustomerLoginInformationDto> LoginCustomer(CustomerLoginDto customerLogin);
        Task UpdateCustomer(UpdateCustomerDto updateCustomer);
        Task UpdateCustomerPassword(UpdateCustomerPasswordDto updateCustomerPassword);
    }
}
