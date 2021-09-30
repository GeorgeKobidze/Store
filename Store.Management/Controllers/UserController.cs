using Domain.Application.Services.Users;
using Domain.Infrastructure.DataTransferObjects.Request.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Management.Controllers
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

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _userService.ResgisterUser(registerUserDto);
            return Ok();
        }
    }
}
