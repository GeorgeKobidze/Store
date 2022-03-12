using Domain.Infrastructure.BaseController;
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
    public class OrderController : BaseController
    {
        public OrderController()
        {

        }

        [Authorize]
        [HttpPost("RegiterOrder")]
        public async Task<IActionResult> RegiterOrder()
        {
            GetAuth();



            return Ok();
        }


    }
}
