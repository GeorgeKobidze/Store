using Domain.Application.Customers;
using Domain.Infrastructure.DataTransferObjects.Customer;
using Domain.Infrastructure.DataTransferObjects.Request.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customService;

        public CustomerController(ICustomerService customService)
        {
            _customService = customService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCustomerDto registerCustomer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _customService.RegisterCustomer(registerCustomer);
            return Ok();
        }


        [HttpPost("LoginCustomer")]
        public async Task<IActionResult> LoginCustomer([FromBody] CustomerLoginDto customerLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _customService.LoginCustomer(customerLogin));
        }

        [Authorize(AuthenticationSchemes ="Bearer")]
        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _customService.UpdateCustomer(updateCustomer);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("UpdateCustomerPassword")]
        public async Task<IActionResult> UpdateCustomerPassword(UpdateCustomerPasswordDto updateCustomerPassword)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _customService.UpdateCustomerPassword(updateCustomerPassword);

            return Ok();
        }

    }
}
