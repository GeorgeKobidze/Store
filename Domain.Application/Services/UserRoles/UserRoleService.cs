using Domain.Infrastructure.Services.UnitOfWork;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.UserRoles
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork<UserRole> _unitOfWork;

        public UserRoleService(IUnitOfWork<UserRole> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUserRoles(List<UserRole> userRole)
        {
            await _unitOfWork.Repository.Add(userRole);
            await _unitOfWork.CommitAsync();
        }
    }
}
