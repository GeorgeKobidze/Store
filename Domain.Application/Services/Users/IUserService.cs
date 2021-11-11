using Domain.Infrastructure.DataTransferObjects.Request.User;
using Domain.Infrastructure.DataTransferObjects.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.Users
{
    public interface IUserService
    {
        Task ResgisterUser(RegisterUserDto registerUser);

        Task<UserLoginInformation> LoginUser(LoginUserDto loginUserDto);

        Task DeleteUser(Guid UserUid);
    }
}
