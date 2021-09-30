using Domain.Infrastructure.DataTransferObjects.Request.User;
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
    }
}
