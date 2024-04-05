using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Core.Entities.Common
{
    public abstract class EntidadBase
    {
        public int Id { get; set; }
        public bool Eliminada { get; set; }
    }
}
