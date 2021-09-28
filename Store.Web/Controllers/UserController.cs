using Domain.ExceptionHandler.CustomException;
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
        public UserController()
        {

        }

        [Authorize]
        [HttpPost("Register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }
       
    }
}
