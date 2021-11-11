using Domain.Application.Services.Users;
using Domain.ExceptionHandler.CustomException;
using Domain.Infrastructure.DataTransferObjects.Request.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("LoginUser")]
        public async Task<IActionResult> Login(LoginUserDto loginUser)
        {            
            return Ok(await _userService.LoginUser(loginUser));
        }


        [Authorize(AuthenticationSchemes = "Bearer",Roles = "Admin")]
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Register(RegisterUserDto registerUser)
        {
            await _userService.ResgisterUser(registerUser);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpGet("DeleteUser")]
        public async Task<IActionResult> DeleteUser(Guid UserUid)
        {
            await _userService.DeleteUser(UserUid);
            return Ok();
        }

       
    }
}
