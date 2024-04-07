using MakersSolutions.Application.DTOs;
using MakersSolutions.Application.Services.Customer;
using MakersSolutions.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakersSolutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> Get()
        {
            try
            {
                var response = await _customerService.GetAllCustomers();

                if (!response.Any())
                    return NotFound("There are not customers...");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Error server...");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            try
            {
                var response = await _customerService.GetCustomer(id);

                if (response is null)
                    return NotFound($"There is not customer with Id ({id})...");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server Error...");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CustomerDto customer)
        {
            try
            {
                var response = await _customerService.AddCustomer(customer);

                return CreatedAtAction(nameof(Post), new { Id = response });
            }
            catch (Exception)
            {
                return BadRequest("Server Error...");
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> Put(CustomerDto customer)
        {
            try
            {
                var response = await _customerService.UpdateCustomer(customer);

                if (response == 0)
                    return NotFound($"There is not customer with Id ({customer.Id})...");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server Error...");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                var response = await _customerService.RemoveCustomer(id);

                if (response == 0)
                    return NotFound($"There is not customer with Id ({id})...");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server Error...");
            }
        }
    }
}
