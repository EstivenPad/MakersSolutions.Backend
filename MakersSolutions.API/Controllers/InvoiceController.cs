using MakersSolutions.Application.DTOs;
using MakersSolutions.Application.Services.Invoice;
using MakersSolutions.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakersSolutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceDto>>> Get()
        {
            try
            {
                var response = await _invoiceService.GetAllInvoices();

                if (!response.Any())
                    return NotFound("There are not invoices...");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Error server...");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceStoredProcedureDto>> Get(int id)
        {
            try
            {
                var response = await _invoiceService.GetInvoice(id);

                if (response is null)
                    return NotFound($"There is not invoice with Id ({id})...");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Server Error...");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(InvoiceDto invoice)
        {
            try
            {
                var response = await _invoiceService.AddInvoice(invoice);
                return CreatedAtAction(nameof(Post), response);
            }
            catch (Exception)
            {
                return BadRequest("Server Error...");
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> Put(InvoiceDto invoice)
        {
            try
            {
                var response = await _invoiceService.UpdateInvoice(invoice);

                if (response == 0)
                    return NotFound($"There is not customer with Id ({invoice.CustomerId})...");
                else if(response == -1)
                    return NotFound($"There is not invoice with Id ({invoice.Id})...");

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
                var response = await _invoiceService.RemoveInvoice(id);

                if (response == 0)
                    return NotFound($"There is not invoice with Id ({id})...");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server Error...");
            }
        }

    }
}
