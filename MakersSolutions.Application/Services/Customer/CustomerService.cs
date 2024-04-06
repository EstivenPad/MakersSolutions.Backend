using AutoMapper;
using MakersSolutions.Application.Contracts;
using MakersSolutions.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Application.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRespository)
        {
            _mapper = mapper;
            _customerRepository = customerRespository;
        }

        public async Task<int?> AddCustomer(CustomerDto customer)
        {
            try
            {
                var customerToCreate = _mapper.Map<Core.Entities.Customer>(customer);

                var customerId = await _customerRepository.CreateAsync(customerToCreate);

                return customerId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CustomerDto>?> GetAllCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetAsync();

                var data = _mapper.Map<List<CustomerDto>>(customers);

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }   

        public async Task<CustomerDto?> GetCustomer(int id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);

                if(customer is null)
                    return null;

                var data = _mapper.Map<CustomerDto>(customer);

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int?> RemoveCustomer(int id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);

                if (customer is null)
                    return null;

                await _customerRepository.DeleteAsync(customer);

                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int?> UpdateCustomer(CustomerDto customer)
        {
            try
            {
                var customerToUpdate = await _customerRepository.GetByIdAsync(customer.Id);

                if (customerToUpdate is null)
                    return null;

                _mapper.Map(customer, customerToUpdate);

                await _customerRepository.UpdateAsync(customerToUpdate);

                return customer.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
