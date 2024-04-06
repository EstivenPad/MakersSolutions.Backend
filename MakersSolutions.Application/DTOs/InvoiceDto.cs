using MakersSolutions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Application.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public string Concept { get; set; } = string.Empty;
        public double Total { get; set; }

        public int CustomerId { get; set; }
        public CustomerDto? Customer { get; set; }
    }
}
