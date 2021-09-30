using Domain.Infrastructure.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using AutoMapper;
using Domain.Infrastructure.DataTransferObjects.Request.CustomerAddress;

namespace Domain.Application.Services.CustomerAddresses
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly IUnitOfWork<CustomerAddress> _unitOfWork;
        private readonly IMapper _imapper;

        public CustomerAddressService(IUnitOfWork<CustomerAddress> unitOfWork,IMapper imapper)
        {
            _unitOfWork = unitOfWork;
            _imapper = imapper;
        }

        public async Task RegisterAdress(CustomerAddress customerAddress)
        {
            await _unitOfWork.Repository.Add(customerAddress);
            await _unitOfWork.CommitAsync();
        }

       

        public async Task UpdateAdress(UpdateCustomerAddressDto updateCustomerAddressDto, Customer customer)
        {
            var customerAddress = _unitOfWork.Repository.Where(e => e.Customer == customer).FirstOrDefault();
            var _customerAddress = _imapper.Map<UpdateCustomerAddressDto,CustomerAddress>(updateCustomerAddressDto,customerAddress);
             _unitOfWork.Repository.Update(_customerAddress);
            await _unitOfWork.CommitAsync();
        }
    }
}
