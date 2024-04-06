using AutoMapper;
using MakersSolutions.Application.Contracts;
using MakersSolutions.Application.DTOs;
using MakersSolutions.Core.Entities;
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
        private readonly ICustomerRepository _clientRepository;

        public InvoiceService(IMapper mapper, IInvoiceRepository invoiceRepository, ICustomerRepository clientRepository)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _clientRepository = clientRepository;
        }
        public async Task<int?> AddInvoice(InvoiceDto invoice)
        {
            try
            {
                var client = await _clientRepository.GetByIdAsync(invoice.ClientId);

                if (client is null)
                    return null;

                var invoiceToCreate = _mapper.Map<Core.Entities.Invoice>(invoice);

                var invoiceId = await _invoiceRepository.CreateAsync(invoiceToCreate);

                return invoiceId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<InvoiceDto>?> GetAllInvoices()
        {
            try
            {
                var invoices = await _invoiceRepository.GetAsync();

                var data = _mapper.Map<List<InvoiceDto>>(invoices);

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<InvoiceDto?> GetInvoice(int id)
        {
            try
            {
                var invoice = await _invoiceRepository.GetByIdAsync(id);

                if (invoice is null)
                    return null;

                var data = _mapper.Map<InvoiceDto>(invoice);

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int?> RemoveInvoice(int id)
        {
            try
            {
                var invoice = await _invoiceRepository.GetByIdAsync(id);

                if (invoice is null)
                    return null;

                await _invoiceRepository.DeleteAsync(invoice);

                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int?> UpdateInvoice(InvoiceDto invoice)
        {
            try
            {
                //Check if client exist
                var client = await _clientRepository.GetByIdAsync(invoice.ClientId);

                if (client is null)
                    return null;

                var invoiceToUpdate = await _invoiceRepository.GetByIdAsync(invoice.Id);

                if (invoiceToUpdate is null)
                    return null;

                _mapper.Map(invoice, invoiceToUpdate);

                await _invoiceRepository.UpdateAsync(invoiceToUpdate);

                return invoice.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
