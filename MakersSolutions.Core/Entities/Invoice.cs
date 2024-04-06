using MakersSolutions.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Core.Entities
{
    public class Invoice : BaseEntity
    {
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public string Concept { get; set; } = string.Empty;
        public double Total { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
