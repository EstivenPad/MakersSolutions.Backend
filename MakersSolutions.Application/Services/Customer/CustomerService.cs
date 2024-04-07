using AutoMapper;
using MakersSolutions.Application.Contracts;
using MakersSolutions.Application.DTOs;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IMapper mapper, ICustomerRepository customerRespository, ILogger<CustomerService> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRespository;
            _logger = logger;
        }

        public async Task<int> AddCustomer(CustomerDto customer)
        {
            try
            {
                var customerToCreate = _mapper.Map<Core.Entities.Customer>(customer);

                var customerId = await _customerRepository.CreateAsync(customerToCreate);

                return customerId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in the AddCustomer method, {ex.Message}");
                throw ex;
            }
        }

        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetAsync();
                var data = _mapper.Map<List<CustomerDto>>(customers);

                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in the GetAllCustomers method, {ex.Message}");
                throw ex;
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
            catch (Exception ex)
            {
                _logger.LogError($"Error in the GetCustomer method, {ex.Message}");
                throw ex;
            }
        }

        public async Task<int> RemoveCustomer(int id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);

                if (customer is null)
                    return 0;

                await _customerRepository.DeleteAsync(customer);

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in the RemoveCustomer method, {ex.Message}");
                throw ex;
            }
        }

        public async Task<int> UpdateCustomer(CustomerDto customer)
        {
            try
            {
                var customerToUpdate = await _customerRepository.GetByIdAsync(customer.Id);

                if (customerToUpdate is null)
                    return 0;

                _mapper.Map(customer, customerToUpdate);

                await _customerRepository.UpdateAsync(customerToUpdate);

                return customer.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in the UpdateCustomer method, {ex.Message}");
                throw ex;
            }
        }
    }
}
