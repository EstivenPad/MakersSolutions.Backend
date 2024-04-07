using MakersSolutions.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Application.Services.Customer
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllCustomers();
        Task<CustomerDto?> GetCustomer(int id);
        Task<int> AddCustomer(CustomerDto customer);
        Task<int> UpdateCustomer(CustomerDto customer);
        Task<int> RemoveCustomer(int id);

    }
}
