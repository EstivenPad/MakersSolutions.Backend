using MakersSolutions.Application.Contracts;
using MakersSolutions.Application.Repositories;
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
    }
}
