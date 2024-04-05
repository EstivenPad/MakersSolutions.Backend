using MakersSolutions.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Core.Entities
{
    public class Factura : EntidadBase
    {
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public int ClienteId { get; set; }
        public string EmitidaPor { get; set; } = string.Empty;
        public string Concepto { get; set; } = string.Empty;
        public double Total { get; set; }
    }
}
