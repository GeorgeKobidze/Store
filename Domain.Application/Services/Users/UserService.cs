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
using Domain.Infrastructure.DataTransferObjects.Response.User;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace Domain.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<User> _unitOfWokr;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Role> _roleunitofWork;
        private readonly IUserRoleService _userRoleService;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork<User> unitOfWokr, IMapper mapper, IUnitOfWork<Role> roleunitofWork, IUserRoleService userRoleService, IConfiguration configuration)
        {
            _unitOfWokr = unitOfWokr;
            _mapper = mapper;
            _roleunitofWork = roleunitofWork;
            _userRoleService = userRoleService;
            _configuration = configuration;
        }



        public async Task<UserLoginInformation> LoginUser(LoginUserDto loginUserDto)
        {
            var _user = _unitOfWokr.Repository.Where(e => e.Email.ToUpper() == loginUserDto.Email.ToUpper()
                                                        && e.Password == Extensions.PassswordHasher(loginUserDto.Password))
                                                        .Include(e => e.UserRoles)
                                                        .ThenInclude(e => e.Role)
                                                        .FirstOrDefault();
            if (_user == null)
                throw new UserNotFoundException();

            var userLoginInformation = _mapper.Map<UserLoginInformation>(_user);

            userLoginInformation.JwtToken = await CreateTokenForUser(_user, _user.UserRoles.ToList()); ;


            return userLoginInformation;
        }

        public async Task ResgisterUser(RegisterUserDto registerUser)
        {
            List<UserRole> userRoles = new();

            var _user = _mapper.Map<User>(registerUser);

            if (_unitOfWokr.Repository.Where(e => e.Email.ToUpper() == _user.Email.ToUpper()).Any())
                throw new EmailAlreadyUsedException();

            if (_unitOfWokr.Repository.Where(e => e.Mobile.ToUpper() == _user.Mobile.ToUpper()).Any())
                throw new MobileAlreadyUsedException();


            _user.Password = Extensions.PassswordHasher(_user.Password);

            foreach (var item in registerUser.UserRoles)
            {
                var _role = await _roleunitofWork.Repository.GetById(item.Uid);

                if (_role == null)
                    throw new RoleNotFoundException();


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

        public async Task DeleteUser(Guid UserUid)
        {
            var _user = await _unitOfWokr.Repository.GetById(UserUid);

            if (_user == null)
                throw new UserNotFoundException();

            _user.Deleted = true;

            _unitOfWokr.Repository.Update(_user);
            await _unitOfWokr.CommitAsync();
        }



        private async Task<string> CreateTokenForUser(User user, List<UserRole> Roles)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Uid.ToString()),
                new Claim(ClaimTypes.Email,user.Email.ToString())
            };

            foreach (var role in Roles)
            {
                var claim = new Claim(ClaimTypes.Role, role.Role.RoleName.ToString());
                claims.Add(claim);
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenhandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenhandler.CreateToken(tokenDescriptor);

            return tokenhandler.WriteToken(token);
        }



    }
}
