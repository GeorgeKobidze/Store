using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.DataTransferObjects.Request.User
{
    public class RegisterUserDto
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public ICollection<UserRolesDto> UserRoles { get; set; }
    }

    public class UserRolesDto
    {
        public Guid Uid { get; set; }
    }
}
