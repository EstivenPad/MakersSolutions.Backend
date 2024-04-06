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
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public string Concept { get; set; } = string.Empty;
        public double Total { get; set; }

        public int ClientId { get; set; }
        public ClientDto? Client { get; set; }
    }
}
