using AutoMapper;
using Domain.Application.Services.CustomerAddresses;
using Domain.Infrastructure.DataTransferObjects.Customer;
using Domain.Infrastructure.Services.UnitOfWork;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Extension;
using Domain.ExceptionHandler.CustomException;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Domain.Infrastructure.DataTransferObjects.Response.Customer;
using Domain.ExceptionHandler.CustomException.CustomerException;
using Domain.Infrastructure.DataTransferObjects.Request.Customer;

namespace Domain.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _imapper;
        private readonly ICustomerAddressService _customerAddressService;
        private readonly IUnitOfWork<Customer> _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork<CustomerAddress> _customerAddressUnitOfWork;

        public CustomerService(IMapper imapper,ICustomerAddressService customerAddressService, 
            IUnitOfWork<Customer> unitOfWork, IConfiguration configuration,
            IUnitOfWork<CustomerAddress> customerAddressUnitOfWork)
        {
            _imapper = imapper;
            _customerAddressService = customerAddressService;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _customerAddressUnitOfWork = customerAddressUnitOfWork;
        }

        public async  Task RegisterCustomer(RegisterCustomerDto registerCustomer)
        {
            var _customer = _imapper.Map<Customer>(registerCustomer);
            _customer.Password = Extensions.PassswordHasher(_customer.Password);
            var _customerAddress = _imapper.Map<CustomerAddress>(registerCustomer.CustomerAddress);

            if (_unitOfWork.Repository.Where(e => e.Email.ToUpper() == _customer.Email.ToUpper()).Any())
            {
                throw new EmailAlreadyUsedException();
            }
            if (_unitOfWork.Repository.Where(e => e.Mobile.ToUpper() == _customer.Mobile.ToUpper()).Any())
            {
                throw new MobileAlreadyUsedException();
            }
            await _unitOfWork.Repository.Add(_customer);

            _customerAddress.Customer = _customer;
            await _customerAddressService.RegisterAdress(_customerAddress);

            await _unitOfWork.CommitAsync();
        }

       

        public async Task<CustomerLoginInformationDto> LoginCustomer(CustomerLoginDto customerLogin)
        {

            var _customer = _unitOfWork.Repository.Where(e => e.Email.ToUpper() == customerLogin.Email.ToUpper() 
                                                            && e.Password == Extensions.PassswordHasher(customerLogin.Password))
                                                            .FirstOrDefault();
            if (_customer == null)            
                throw new CustomerNotFoundException();

            var CustomerLoginInformation = _imapper.Map<CustomerLoginInformationDto>(_customer);

            CustomerLoginInformation.JwtToken = await CreateTokenForCustomer(_customer);

            return CustomerLoginInformation;

        }



       

        public async Task UpdateCustomer(UpdateCustomerDto updateCustomer)
        {
            var customer = _unitOfWork.Repository.GetById(updateCustomer.Uid).Result;

            if (customer == null)
            {
                throw new CustomerNotFoundException();
            }

            if (_unitOfWork.Repository.Where(e => e.Email.ToUpper() == updateCustomer.Email.ToUpper() && e.Uid != updateCustomer.Uid).Any())
            {
                throw new EmailAlreadyUsedException();
            }
            if (_unitOfWork.Repository.Where(e => e.Mobile.ToUpper() == updateCustomer.Mobile.ToUpper() && e.Uid != updateCustomer.Uid).Any())
            {
                throw new MobileAlreadyUsedException();
            }

            var _customer = _imapper.Map<UpdateCustomerDto,Customer>(updateCustomer, customer);
            _unitOfWork.Repository.Update(_customer);
            await _customerAddressService.UpdateAdress(updateCustomer.CustomerAddress, _customer);

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCustomerPassword(UpdateCustomerPasswordDto updateCustomerPassword)
        {
            var customer = await _unitOfWork.Repository.GetById(updateCustomerPassword.Uid);
            if (customer == null)
            {
                throw new CustomerNotFoundException();
            }

            if (customer.Password != Extensions.PassswordHasher(updateCustomerPassword.OldPassword))
            {
                throw new OldPasswordIsNotCorrectEcxpetion();
            }
            customer.Password = Extensions.PassswordHasher(updateCustomerPassword.NewPassword);

            _unitOfWork.Repository.Update(customer);
            await _unitOfWork.CommitAsync();

        }


        private async Task<string> CreateTokenForCustomer(Customer customer)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,customer.Uid.ToString()),
                new Claim(ClaimTypes.Email,customer.Email.ToString())
            };

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
