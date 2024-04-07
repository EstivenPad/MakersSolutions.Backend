using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Application.DTOs
{
    public class InvoiceStoredProcedureDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public string Concept { get; set; } = string.Empty;
        public double Total { get; set; }
        public int CustomerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
