using AutoMapper;
using Domain.Application.Services.UserRoles;
using Domain.ExceptionHandler.CustomException;
using Domain.Infrastructure.DataTransferObjects.Request.User;
using Domain.Infrastructure.Services.UnitOfWork;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Extension;

namespace Domain.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<User> _unitOfWokr;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Role> _roleunitofWork;
        private readonly IUserRoleService _userRoleService;

        public UserService(IUnitOfWork<User> unitOfWokr,IMapper mapper,IUnitOfWork<Role> roleunitofWork,IUserRoleService userRoleService)
        {
            _unitOfWokr = unitOfWokr;
            _mapper = mapper;
            _roleunitofWork = roleunitofWork;
            _userRoleService = userRoleService;
        }

        public async Task ResgisterUser(RegisterUserDto registerUser)
        {
            List<UserRole> userRoles = new();

            var _user = _mapper.Map<User>(registerUser);

            if (_unitOfWokr.Repository.Where(e => e.Email.ToUpper() == _user.Email.ToUpper()).Any())
            {
                throw new EmailAlreadyUsedException();
            }
            if (_unitOfWokr.Repository.Where(e => e.Mobile.ToUpper() == _user.Mobile.ToUpper()).Any())
            {
                throw new MobileAlreadyUsedException();
            }

            _user.Password = Extensions.PassswordHasher(_user.Password);

            foreach (var item in registerUser.UserRoles)
            {
                var _role = await _roleunitofWork.Repository.GetById(item.Uid);

                if (_role == null)
                {
                    throw new RoleNotFoundException();
                }

                var userrole = new UserRole()
                {
                    UserUid = _user.Uid,
                    RoleUid = _role.Uid
                };
                userRoles.Add(userrole);
            }
            _user.UserRoles = userRoles;

            await _unitOfWokr.Repository.Add(_user);
            await _unitOfWokr.CommitAsync();
        }




    }
}
