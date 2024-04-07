using AutoMapper;
using MakersSolutions.Application.Contracts;
using MakersSolutions.Application.DTOs;
using MakersSolutions.Application.Services.Customer;
using MakersSolutions.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Application.Services.Invoice
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<InvoiceService> _logger;

        public InvoiceService(IMapper mapper, IInvoiceRepository invoiceRepository, ICustomerRepository customerRepository, ILogger<InvoiceService> logger)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public async Task<int> AddInvoice(InvoiceDto invoice)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(invoice.CustomerId);

                if (customer is null)
                    return 0;

                var invoiceToCreate = _mapper.Map<Core.Entities.Invoice>(invoice);

                var invoiceId = await _invoiceRepository.CreateAsync(invoiceToCreate);

                return invoiceId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in the AddInvoice method, {ex.Message}");
                throw ex;
            }
        }

        public async Task<List<InvoiceDto>> GetAllInvoices()
        {
            try
            {
                var invoices = await _invoiceRepository.GetAsync();

                var data = _mapper.Map<List<InvoiceDto>>(invoices);

                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in the GetAllInvoices method, {ex.Message}");
                throw ex;
            }
        }

        public async Task<InvoiceStoredProcedureDto?> GetInvoice(int id)
        {
            try
            {
                var invoice = await _invoiceRepository.GetByIdFromStoredProcedureAsync(id);

                if (invoice is null)
                    return null;

                return _mapper.Map<InvoiceStoredProcedureDto>(invoice);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in the GetInvoice method, {ex.Message}");
                throw ex;
            }
        }

        public async Task<int> RemoveInvoice(int id)
        {
            try
            {
                var invoice = await _invoiceRepository.GetByIdAsync(id);

                if (invoice is null)
                    return 0;

                await _invoiceRepository.DeleteAsync(invoice);

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in the RemoveInvoice method, {ex.Message}");
                throw ex;
            }
        }

        public async Task<int> UpdateInvoice(InvoiceDto invoice)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(invoice.CustomerId);

                if (customer is null)
                    return 0;

                var invoiceToUpdate = await _invoiceRepository.GetByIdAsync(invoice.Id);

                if (invoiceToUpdate is null)
                    return -1;

                _mapper.Map(invoice, invoiceToUpdate);

                await _invoiceRepository.UpdateAsync(invoiceToUpdate);

                return invoice.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in the UpdateInvoice method, {ex.Message}");
                throw ex;
            }
        }
    }
}
