using Domain.Application.Customers;
using Domain.Infrastructure.BaseController;
using Domain.Infrastructure.DataTransferObjects.Customer;
using Domain.Infrastructure.DataTransferObjects.Request.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
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
            var user = GetAuth();
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


        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer()
        {
            GetAuth();
            return Ok();
        }


    }
}
