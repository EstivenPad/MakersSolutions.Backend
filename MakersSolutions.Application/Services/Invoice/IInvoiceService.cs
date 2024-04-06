using MakersSolutions.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Application.Services.Invoice
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDto>> GetAllInvoice();
        Task<InvoiceDto> GetInvoice(int id);
        Task AddInvoice(InvoiceDto client);
        Task UpdateInvoice(InvoiceDto client);
        Task DeleteInvoice(int id);
    }
}
