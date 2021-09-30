using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.UserRoles
{
    public interface IUserRoleService
    {
        Task AddUserRoles(List<UserRole> userRole);
    }
}
