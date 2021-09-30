using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.DataTransferObjects.Response.Customer
{
    public class CustomerLoginInformationDto
    {
        public Guid Uid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public string JwtToken { get; set; }
    }
}
