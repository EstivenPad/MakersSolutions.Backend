﻿using MakersSolutions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Application.Contracts
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Task<InvoiceStoredProcedure> GetByIdFromStoredProcedureAsync(int id);
    }
}
