using Domain.Infrastructure.DataTransferObjects.Customer;
using Domain.Infrastructure.DataTransferObjects.Request.CustomerAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.DataTransferObjects.Request.Customer
{
    public class UpdateCustomerDto
    {
        public Guid Uid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public UpdateCustomerAddressDto CustomerAddress { get; set; }
    }


  
    

}
