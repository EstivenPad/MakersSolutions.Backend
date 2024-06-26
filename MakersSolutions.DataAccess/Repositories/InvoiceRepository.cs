﻿using MakersSolutions.Application.Contracts;
using MakersSolutions.Core.Entities;
using MakersSolutions.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.DataAccess.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DataContext context) : base(context)
        {
        }

        public override async Task<List<Invoice>> GetAsync()
        {
            var invoices = await _context.Invoices
                .FromSqlRaw("EXEC SP_GetAllInvoices").ToListAsync();
            
            return invoices;
        }

        public async Task<InvoiceStoredProcedure> GetByIdFromStoredProcedureAsync(int id)
        {
            var invoice = await _context.InvoicesStoredProcedure
                .FromSqlInterpolated($"EXEC SP_GetInvoice {id}")
                .ToListAsync();

            return invoice.FirstOrDefault();
        }
    }
}
