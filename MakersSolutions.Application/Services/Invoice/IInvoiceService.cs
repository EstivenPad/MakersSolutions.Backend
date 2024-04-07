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
        Task<List<InvoiceDto>> GetAllInvoices();
        Task<InvoiceStoredProcedureDto?> GetInvoice(int id);
        Task<int> AddInvoice(InvoiceDto invoice);
        Task<int> UpdateInvoice(InvoiceDto invoice);
        Task<int> RemoveInvoice(int id);
    }
}
